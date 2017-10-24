namespace SimpleMvc.Framework.Security
{
    public class Authentication
    {
        internal Authentication()
        {
            this.IsAuthenticated = false;
        }

        internal Authentication(string name)
        {
            this.IsAuthenticated = true;
            this.Name = name;
        }

        public bool IsAuthenticated { get; private set; }

        public string Name { get; private set; }
    }
}
