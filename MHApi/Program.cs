var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

// Swagger for testing
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/rates", GetRate);

app.Run();

static IResult GetRate(string loanType, int term)
{
    // Validation of input
    if (term <= 0)
    {
        return Results.BadRequest(new
        {
            error = "Input valid loan term."
        });
    }
    if (loanType != "owner-occupied" && loanType != "residential-investor")
    {
        return Results.BadRequest(new
        {
            error = "Input valid loan type."
        });   
    }

    // Calculate the loan type rate for either owner occupied or residential investor 
    decimal loanRate = loanType switch
    {
        "owner-occupied" => 0.0525m,
        _ => 0.0625m
    };

    var rate = loanRate * term;
    var result = new RateDto
    {
        LoanType = loanType,
        Term = term,
        Rate = rate
    };
    return Results.Ok(result);
}



