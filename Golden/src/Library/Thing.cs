using Newtonsoft.Json;

namespace Library
{
    public class Thing
    {
        public int Get(int number) => JsonConvert.DeserializeObject<int>($"{number}");
    }
}
