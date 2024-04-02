public static class InputFilter {
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
}