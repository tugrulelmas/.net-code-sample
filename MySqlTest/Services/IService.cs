namespace MySqlTest
{
	public interface IService
	{
	}

	public interface IUserService : IService
	{
		void Add();
	}

	public class UserService : IUserService
	{
		public void Add() {
		}
	}
}
