namespace MinAPI.Model
{
    public class StatsResult
    {
        public int Id { get; set; }

        /// <summary>
        /// source of text for analysis (url, file name..)
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Name if applicable (book title etc)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// how long was the analysis running
        /// </summary>
        public int ElapsedMilliseconds { get; set; }

        /// <summary>
        /// 10 most commonn words in source
        /// </summary>
        public Dictionary<string, int> Top10Words { get; set; }

        /// <summary>
        /// Who submitted this statsResults
        /// </summary>
        public string SubmitedBy { get; set; }
    }
}
