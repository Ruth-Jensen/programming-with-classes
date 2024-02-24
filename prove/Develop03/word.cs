public class Word{
    public Word(){

    }
    public List<string> ReplaceWord (List<string> scripture)
    {
        Random random = new Random();
        int index;

        do{
            index = random.Next(0,scripture.Count);
            if (IsBlank(index, scripture) == false){
                scripture[index] = new string('-', scripture[index].Length);
                break;
            }
        }
        while(IsBlank(index, scripture));

        do{
            index = random.Next(0,scripture.Count);
            if (IsBlank(index, scripture) == false){
                scripture[index] = new string('-', scripture[index].Length);
                break;
            }
        }
        while(IsBlank(index, scripture));

        do{
            index = random.Next(0,scripture.Count);
            if (IsBlank(index, scripture) == false){
                scripture[index] = new string('-', scripture[index].Length);
                break;
            }
        }
        while(IsBlank(index, scripture));

        return scripture;
    }

    private bool IsBlank (int index, List<string> scripture){

        if (scripture[index].StartsWith("-")){

            foreach (string word in scripture){
                if(!word.StartsWith("-")){
                    
                    // IsBlank returns true if the word starts with "-" and there are words that don't start with "-"
                    return true;  
                }
            }

            // IsBlank returns false if all the words are blank (there is nothing left to erase)
            return false;
        }
        else{
            // IsBlank returns false if the word doesn't start with "-"
            return false;
        }
    }
}