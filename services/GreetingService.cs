using datas;
using models;

namespace services
{
    public class GreetingService
    {
        private Repository _respository;
        public GreetingService(Repository respository)
        {
            _respository = respository;
        }
        public virtual GreetingModel GetGreetings(string name = "")
        {
            var data = _respository.GetGreeting(1);
            return new GreetingModel()
            {
                Greetings = $"{data.Greetings} {name}!"
            };
        }
    }
}