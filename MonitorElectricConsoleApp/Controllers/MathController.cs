using Microsoft.AspNetCore.Mvc;
using MonitorElectricConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MonitorElectricConsoleApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathController : Controller
    {
        /// <summary>
        /// (1)-метод (сумма двух чисел)
        /// </summary>
        /// <param name="first">первый аргумент</param>
        /// <param name="second">второй аргумент</param>
        /// <returns>резульат сложения</returns>
        [HttpGet("[action]")]
        public IActionResult Sum([FromQuery] string first, [FromQuery] string second)
        {
            DateTime currentTime = DateTime.Now;
            if (int.TryParse(first, out int num1) && int.TryParse(second, out int num2))
            {
                int result = num1 + num2;
                using (AppContext app = new AppContext())
                {
                    Result resObj = new Result()
                    {
                        FirstArg = num1,
                        SecondArg = num2,
                        CurrentTime = currentTime,
                        Total = result
                    };
                    app.Results.Add(resObj);
                    app.SaveChanges();
                }
                return Ok(result);
            }
            else
            {
                return BadRequest("Ошибка при попытке сложения. Используйте числа!");
            }
        }

        /// <summary>
        /// (2)-метод (деление двух чисел)
        /// </summary>
        /// <param name="first">первый аргумент</param>
        /// <param name="second">второй аргумент</param>
        /// <returns>результат деления</returns>
        [HttpGet("[action]")]
        public IActionResult Div([FromQuery] string first, [FromQuery] string second)
        {
            DateTime currentTime = DateTime.Now;
            if (int.TryParse(first, out int num1) && int.TryParse(second, out int num2))
            {
                double result = (double)num1 / num2;
                using (AppContext app = new AppContext())
                {
                    Result resObj = new Result()
                    {
                        FirstArg = num1,
                        SecondArg = num2,
                        CurrentTime = currentTime,
                        Total = result
                    };
                    app.Results.Add(resObj);
                    app.SaveChanges();
                }
                return Ok(result);
            }
            else
            {
                return BadRequest("Ошибка при попытке сложения. Используйте числа!");
            }
        }

        /// <summary>
        /// (3)-метод (два потока)
        /// </summary>
        /// <returns>результат</returns>
        [HttpGet("[action]")]
        public IActionResult ParallelNoSafely()
        {
            int result = 0;

            Thread thread1 = new Thread(() => { while (true) result++; });
            Thread thread2 = new Thread(() => { while (true) result--; });

            thread1.Start();
            thread2.Start();
            Thread.Sleep(15000);            

            return Ok(result);
        }

        /// <summary>
        /// (4)-метод (два потока (безопасно))
        /// </summary>
        /// <returns>результат</returns>
        [HttpGet("[action]")]
        public IActionResult ParallelSafely()
        {
            int result = 0;
            object locker = new object();//заглушка

            Thread thread1 = new Thread(() =>
            {
                while (true)
                {
                    lock (locker)
                    {
                        result++;
                    }
                }
            });

            Thread thread2 = new Thread(() =>
            {
                while (true)
                {
                    lock (locker)
                    {
                        result--;
                    }
                }
            });

            thread1.Start();
            thread2.Start();
            Thread.Sleep(15000);

            return Ok(result);
        }
    }
}
