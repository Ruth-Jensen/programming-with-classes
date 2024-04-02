public static class Warning {
    public static int NumberFilter(string input, int range) {
        try {

            int intInput = int.Parse(input) - 1;
            int zeroRange = range - 1;

            if (intInput >= 0 && intInput <= range) {
                return intInput;
            }
            else {
                return -1;
            }
        }
        catch { return -1; }
    }

    public static void FlashString(string text, int durationSeconds)
    {
        for(int x = 0; x < durationSeconds; x++){
            Console.Write(text);
            Thread.Sleep(100);
            for(int i = 0; i < text.Length; i++){
                Console.Write("\b");
            }
            for(int i = 0; i < text.Length; i++){
                Console.Write(" ");
            }
            for(int i = 0; i < text.Length; i++){
                Console.Write("\b");
            }
            Thread.Sleep(100); 
        }
        Console.WriteLine(text);
    }
    public static void FlashColor(int durationSeconds, string color){
        for(int x = 0; x < durationSeconds; x++){
            if(color == "red"){
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if(color == "green"){
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}