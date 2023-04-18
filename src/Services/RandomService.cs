namespace ProvaPub.Services
{
	public class RandomService
	{
		private Random _random;
		public RandomService()
		{
			_random = new Random(Guid.NewGuid().GetHashCode());
		}
		public int GetRandom()
		{
			return _random.Next();
		}

	}
}
