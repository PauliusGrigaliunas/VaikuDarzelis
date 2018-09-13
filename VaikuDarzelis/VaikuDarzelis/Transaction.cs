namespace VaikuDarzelis
{
    public class Transaction
    {

        public int DARZ_ID { get; set; }
        public string SCHOOL_NAME { get; set; }
        public int TYPE_ID { get; set; }
        public string TYPE_LABEL { get; set; }
        public int LAN_ID { get; set; }
        public string LAN_LABEL { get; set; }
        public int CHILDS_COUNT { get; set; }
        public int FREE_SPACE { get; set; }
        public static Transaction FromLine(string line)
        {
            var data = line.Split(',');
            return new Transaction
            {

            };
        }
    }
}
