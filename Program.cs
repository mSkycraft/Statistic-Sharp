using System.Text.RegularExpressions;

string pathR = "Анна каренина.txt";
string pathW = "Анна каренина.Подсчет слов.txt";

Dictionary<string,int>  dict = new Dictionary<string, int>();
string line = "";

void LoadFile(string p){
    using (StreamReader reader = File.OpenText(p))
    {
        while(!reader.EndOfStream)
        {
            line = reader.ReadLine();
            line = Regex.Replace(line,@"[^а-яА-Я|^\s|^\n]","");
            string[] textFile = new string[line.Split(' ').Length];
            textFile = line.Split(" ");
            for(int i = 0; i< textFile.Length;i++)
            {    
                if((textFile[i] != null)&&(textFile[i]!= ""))
                    if(dict.ContainsKey(textFile[i].ToLower()))
                    {
                        dict[textFile[i].ToLower()] += 1;
                    }
                    else
                    {
                        dict[textFile[i].ToLower()] = 1;
                    }
            }
        }
    }
}

void WriteResult(string p){
    using (StreamWriter writer = new StreamWriter(p,false)){
        foreach(var item in dict)
        {
            writer.WriteLine(item.Key + " : " + item.Value);
        }
    }
}

void main(){
    LoadFile(pathR);
    Console.WriteLine(dict.Count.ToString());
    dict = dict.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
    WriteResult(pathW);
}

main();