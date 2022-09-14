static void Init()
{
    List<int> list = new();
    int cant_arr = read_console_number("Please insert limit of array:", 1, 15);

    Console.Clear();

    int number_input;

    for (int i = 0; i < cant_arr; i++)
    {
        number_input = read_console_number("Please insert a number:");
        list.Add(number_input);
    }

    Console.WriteLine("\n\n---------------------------------\n\n");

    int option = 0;
    List<int> temp_list;
    int temp_val;
    int temp_val_search;

    while (option != 6)
    {
        Console.Clear();

        temp_list = new();
        temp_val = 0;
        temp_val_search = 0;

        Console.WriteLine("Select option: ");
        Console.WriteLine("1. Sort ASC.");
        Console.WriteLine("2. Sort DSC.");
        Console.WriteLine("3. Search element.");
        Console.WriteLine("4. Add element.");
        Console.WriteLine("5. Repeat elements.");
        Console.WriteLine("6. Exit.");
        option = read_console_number("Please select a option:", 1, 6);

        Console.WriteLine("\n\n---------------------------------");
        switch (option)
        {
            case 1:
                temp_list = list.OrderBy(item => item).ToList();
                print_arr("The ASC order is: ", temp_list);
                break;
            case 2:
                temp_list = list.OrderByDescending(item => item).ToList();
                print_arr("The DSC order is: ", temp_list);
                break;
            case 3:
                temp_val_search = read_console_number("Please insert the number to search:");
                temp_val = list.FindIndex(item => item == temp_val_search);

                if (temp_val != -1)
                {
                    Console.WriteLine("\n\nThe value " + temp_val_search + " has been found in the position of array number: " + temp_val + "\n\n");
                    Thread.Sleep(2000);
                }
                else
                {
                    handle_error("The value has not been found...");
                }
                break;
            case 4:
                number_input = read_console_number("Please insert the number to be added to the array:");
                list.Add(number_input);
                break;
            case 5:
                HashSet<int> hashSet = new();
                temp_list = list.Where(e => !hashSet.Add(e)).ToList();
                print_arr("The repeat items are " + temp_list.Count + ": ", temp_list);
                break;
            case 6:
                Console.WriteLine("Thanks...");
                break;
        }

        Console.WriteLine("---------------------------------\n\n");
        Thread.Sleep(2000);
        Console.Clear();
    }
}

static int read_console_number(string alert, int? min = -1000, int? max = 1000)
{
    string line_read;
    int value;

    while (true)
    {
        try
        {
            Console.WriteLine(alert);
            line_read = Console.ReadLine();

            if (line_read is null)
            {
                handle_error("Not null allowed...");

                continue;
            }

            value = Int32.Parse(line_read);

            if (min is not null && max is not null && !(value >= min && value <= max))
            {
                handle_error("Not in limits, insert a number between: " + min + " and " + max);

                continue;
            }

            return value;
        }
        catch (Exception)
        {
            handle_error("Is not a number, please insert just numbers");
        }
    }
}

static void print_arr(string msg, List<int> list)
{
    Console.WriteLine(msg);
    Console.WriteLine(string.Join(", ", list));
}

static void handle_error(string msg, int seconds = 2)
{
    Console.WriteLine("-- " + msg + " --\n\n");
    Thread.Sleep(seconds * 1000);
    Console.Clear();
}

Init();