namespace VaikuDarzelis
{
    public class Kindergarten
    {
        public int DARZ_ID { get; set; }
        public string SCHOOL_NAME { get; set; }
        public int TYPE_ID { get; set; }
        public string TYPE_LABEL { get; set; }
        public int LAN_ID { get; set; }
        public string LAN_LABEL { get; set; }
        public int CHILDS_COUNT { get; set; }
        public int FREE_SPACE { get; set; }

        public Kindergarten(string line)
        {
            var data = line.Split(';');

            DARZ_ID = int.Parse(data[0]);
            SCHOOL_NAME = data[1];
            TYPE_ID = int.Parse(data[2]);
            TYPE_LABEL = data[3];
            LAN_ID = int.Parse(data[4]);
            LAN_LABEL = data[5];
            CHILDS_COUNT = int.Parse(data[6]);
            FREE_SPACE = int.Parse(data[7]);
        }

        public decimal Ratio() => ((CHILDS_COUNT + FREE_SPACE == 0) ? 0 : FREE_SPACE / (CHILDS_COUNT + FREE_SPACE));
    }
}
