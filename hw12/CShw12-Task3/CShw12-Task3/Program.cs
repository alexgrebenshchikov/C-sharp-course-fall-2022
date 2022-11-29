using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace task3
{
    class Solution
    {
        public static CommandSeq FindShortestSeq(Position target)
        {
            const int maxPosition = 10_000;
            if (target.x > maxPosition)
            {
                return new CommandSeq();
            }
            var used = new Dictionary<State, bool>();
            var par = new Dictionary<State, (Command, State)>();

            var q = new Queue<State>();
            q.Enqueue(new State(0, 1));
            used[new State(0, 1)] = true;
            var res = new CommandSeq();
            while (q.Count > 0)
            {
                var v = q.Dequeue();

                var toA = new State(v.pos + v.speed, Math.Abs(v.speed) * 2);
                if (toA.pos == target.x)
                {
                    res.Add(Command.A);
                    var curState = v;
                    while (curState.pos != 0) {
                        var parent = par[curState];
                        res.Add(parent.Item1);
                        curState = parent.Item2;
                    }
                    res.Reverse();
                    break;
                }
                var toR = new State(v.pos, -1);
                if (toA.pos > 0 && toA.pos <= maxPosition && !used.GetValueOrDefault(toA, false))
                {
                    q.Enqueue(toA);
                    used[toA] = true;
                    par[toA] = (Command.A, v);
                }
                if (toR.pos > 0 && toR.pos <= maxPosition && !used.GetValueOrDefault(toR, false))
                {
                    q.Enqueue(toR);
                    used[toR] = true;
                    par[toR] = (Command.R, v);
                }
            }
            return res;
        }

        public class CommandSeq
        {
            private List<Command> commands = new List<Command>();
            public void Add(Command cmd)
            {
                commands.Add (cmd);
            }
            public void Reverse() {
                commands.Reverse();
            }
            public override string ToString()
            {
                return String.Join("", commands);
            }
        }

        public enum Command
        {
            A, R
        }

        public class Position
        {
            public int x;
            public Position(int x) { this.x = x; }
        }

        private class State
        {
            public int pos;
            public int speed;
            public State(int pos, int speed)
            {
                this.pos = pos; this.speed = speed;
            }
            public override bool Equals(object? obj)
            {
                if (obj == null)
                {
                    return false;
                }
                else
                {
                    if (obj.GetType() == typeof(State))
                    {
                        return pos == ((State)obj).pos && speed == ((State)obj).speed;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            public override int GetHashCode()
            {
                return 51 * pos + 31 * speed;
            }
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            var res = Solution.FindShortestSeq(new Solution.Position(3));
            Console.WriteLine(res);
            res = Solution.FindShortestSeq(new Solution.Position(6));
            Console.WriteLine(res);
        }
    }
}
