using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Core.Commands;

public class CommandExecutor
{
    private readonly ICoreMechanics _mechanics;

    public CommandExecutor(ICoreMechanics mechanics) =>
        _mechanics = mechanics;

    public IEnumerable<ICommand> Execute(ICommand command)
    {
        var queueOfCommands = new Queue<ICommand>();
        queueOfCommands.Enqueue(command);

        while (queueOfCommands.Count > 0)
        {
            var next = queueOfCommands.Dequeue();
            var result = next.Execute(_mechanics);
            
            yield return next;
            
            if (result.IsFailure)
                continue;

            foreach (var child in next.Children) 
                queueOfCommands.Enqueue(child);
        }
    }
}