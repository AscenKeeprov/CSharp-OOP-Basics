using Forum.App.UserInterface.Contracts;

namespace Forum.App.Controllers.Contracts
{
    public interface IController
    {
	IView GetView(string userName);
	MenuState ExecuteCommand(int index);
    }
}
