namespace MathApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Run(async (HttpContext context) =>
            {
                if (context.Request.Method == "GET" && context.Request.Path == "/")
                {
                    int firstNumber = 0, secondNumber = 0;
                    string operation = null;
                    long? result = null;
                    if (context.Request.Query.ContainsKey("firstNumber"))
                    {
                        try
                        {
                            firstNumber = Int32.Parse(context.Request.Query["firstNumber"]);
                        }
                        catch (Exception ex)
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsync("Invalid input for firstNumber\n");
                        }
                    }
                    if (context.Request.Query.ContainsKey("secondNumber"))
                    {
                        try
                        {
                            secondNumber = Int32.Parse(context.Request.Query["secondNumber"]);
                        }
                        catch (Exception ex)
                        {
                            if (context.Response.StatusCode == 200)
                            {
                                context.Response.StatusCode = 400;
                            }
                            //context.Response.StatusCode = 400;
                            await context.Response.WriteAsync("Invalid input for secondNumber\n");
                        }

                    }
                    if (context.Request.Query.ContainsKey("operation"))
                    {
                        operation = context.Request.Query["operation"].ToString();

                        if (!string.IsNullOrEmpty(operation))
                        {
                            
                            switch (operation)
                            {
                                case "add":
                                    result = firstNumber + secondNumber;
                                    break;
                                case "subtract":
                                    result = firstNumber - secondNumber;
                                    break;
                                case "multiply":
                                    result = firstNumber * secondNumber;
                                    break;
                                case "divide":
                                    if(secondNumber != 0)
                                    {
                                        result = firstNumber / secondNumber;
                                    }
                                    else
                                    {
                                        context.Response.WriteAsync("Invalid operation: Divison by zero\n");
                                    }
                                    break;
                                case "mod":
                                    if (secondNumber != 0)
                                    {
                                        result = firstNumber % secondNumber;
                                    }
                                    else
                                    {
                                        context.Response.WriteAsync("Invalid operation: Divison by zero\n");
                                    }
                                    break;
                                default:
                                    if (context.Response.StatusCode == 200)
                                    {
                                        context.Response.StatusCode = 400;
                                        
                                    }
                                    await context.Response.WriteAsync("Invalid input for operation\n");
                                    break;
                            }
                            if(result != null)
                            {
                                await context.Response.WriteAsync(result.Value.ToString());
                            }
                            
                        }
                        if (context.Response.StatusCode == 200)
                        {
                            context.Response.StatusCode = 400;

                        }
                        await context.Response.WriteAsync("Invalid input for operation\n");

                    }
                }

            });

            app.Run();
        }
    }
}
