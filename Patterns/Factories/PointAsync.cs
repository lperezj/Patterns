using System;
using System.Threading.Tasks;

namespace Patterns.Factories
{
    public class PointAsync
    {
        Double x, y;

        private PointAsync(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        private async Task<PointAsync> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}  {nameof(y)}: {y}";
        }

        public static Task<PointAsync> CreateAsync(Double x, Double y)
        {
            var result = new PointAsync(x ,y);
            return result.InitAsync();
        }
    }
}
