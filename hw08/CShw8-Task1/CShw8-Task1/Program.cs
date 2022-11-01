using System.Text;

namespace task1 {
    class Task1 {
        public static String SerializeAndDeserialize(String str) {
            var bytes = Encoding.UTF8.GetBytes(str);
            var newS = Encoding.UTF8.GetString(bytes);
            return newS;
        }
    }

    class Program {
        public static void Main(string[] args) {
            var ruPangramm = "В чащах юга жил бы цитрус? Да, но фальшивый экземпляр!";
            var dePangramm = "Franz jagt im komplett verwahrlosten Taxi quer durch Bayern";
            var japPangramm = "いろはにほへと ちりぬるを わかよたれそ つねならむ うゐのおくやま けふこえて あさきゆめみし ゑひもせす";
            Console.WriteLine(Task1.SerializeAndDeserialize(ruPangramm) == ruPangramm);
            Console.WriteLine(Task1.SerializeAndDeserialize(dePangramm) == dePangramm);
            Console.WriteLine(Task1.SerializeAndDeserialize(japPangramm) == japPangramm);
        }
    }
}
