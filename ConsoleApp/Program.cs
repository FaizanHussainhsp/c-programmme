

string[] productNames = new string[1];
int[] productPrices=new int[1];
double[] gsts = new double[1];
double[] totalPrices= new double[1];
int counter = 0;

bool shouldContinue = true;
while (shouldContinue)
{
    Console.WriteLine("===============Menu===================");
    Console.WriteLine("1. Enter Products Detail");
    Console.WriteLine("2. Read Products Detail");
    Console.WriteLine("3. Exit");
    Console.Write("Enter Your Choice: ");
    int choice=Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            bool isBreak= addProductDetail();
            if (isBreak)
            {
                shouldContinue = false;
            }
            break;
        case 2:
            Console.Clear();
            displayDetail();
            
            break;
        case 3:
            shouldContinue= false;
            break;
        default:
            Console.WriteLine("You Entered Wrong data");
            break;
    }

}

bool addProductDetail()
{


    Console.Write("Enter Product-Name: ");
    string productName = Console.ReadLine();
    if (string.IsNullOrEmpty(productName))
    {
        return true ;
    }

    Console.Write("Enter Product-Price: ");
    int productPrice =Convert.ToInt32( Console.ReadLine());
    if (productPrice <= 0)
    {
        return true;
    }
    Console.Write("Enter Product-GST %: ");
    string? prod = Console.ReadLine();
    if(string.IsNullOrEmpty(prod))
    {
        return true;
    }
    double productGST = Convert.ToDouble(prod);
    double totalPrice = ((productPrice / 100) * productGST)+productPrice;

    if (counter == 0)
    {
        productNames[0] = productName;
        productPrices[0] = productPrice;
        gsts[0] = productGST;
        totalPrices[0] = totalPrice;
        ++counter;
    }
    else
    {

        string[] newProductNames = new string[productNames.Length+1];
        int[] newProductPrices = new int[productPrices.Length+1];
        double[] newGsts = new double[gsts.Length+1];
        double[] newTotalPrice = new double[totalPrices.Length+1];
        //create deep copy
        
        productNames.CopyTo(newProductNames, 0);
        productPrices.CopyTo(newProductPrices, 0);
        gsts.CopyTo(newGsts, 0);
        totalPrices.CopyTo(newTotalPrice, 0);
        //assign value to deep  copy
        newProductNames[counter]= productName;
        newProductPrices[counter]= productPrice;
        newGsts[counter] = productGST;
        newTotalPrice[counter] = totalPrice;
        // resign deep copy reference to gloal reference variables
        productNames = newProductNames;
        productPrices = newProductPrices;
        gsts = newGsts;
        totalPrices = newTotalPrice;
        ++counter;
    }


    return false;
}


void displayDetail()
{
    Console.WriteLine("index\tproduct\tgst-%\tprice\ttotalPrice");
    Console.WriteLine("===========================================");
    for (int i = 0; i < productNames.Length; i++)
    {
        Console.WriteLine($"{i}\t{productNames[i]}\t{gsts[i]}\t{productPrices[i]}\t{totalPrices[i]}");
    }
    Console.WriteLine("===========================================");
}
