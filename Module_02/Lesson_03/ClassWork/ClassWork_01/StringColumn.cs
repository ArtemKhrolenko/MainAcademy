namespace ClassWork_01
{
    class StringColumn
    {
        private const int Size2 = 3;
        private string[] _strColumn = new string[Size2];

        public StringColumn()
        {
            for (int i = 0; i < Size2; i++)
            {
                this[i] = "!";
            }
        }

        public string this[int x]
        {
            get => _strColumn[x];
            set => _strColumn[x] = value;
        }

        public static StringMatrix operator +(StringMatrix tlb1, StringColumn tbl2)
        {
            StringMatrix _resStrMatrix = new StringMatrix();
            for (int i = 0; i < StringMatrix.Size1; i++)
            {
                for (int j = 0; j < Size2; j++)
                {
                    _resStrMatrix[i, j] = tlb1[i, j] + " " + tbl2[j];
                }
            }

            return _resStrMatrix;
        }
    }
}