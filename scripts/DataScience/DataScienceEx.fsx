#r "nuget:Microsoft.Spark"

open Microsoft.Spark.Sql

let sparkSession =
    SparkSession
        .Builder()
        .AppName("esuite-report")
        .GetOrCreate()

// Load data into Spark DataFrame

let df =
    sparkSession
        .Read()
        .Option("header", "true")
        .Option("inferSchema", "true")
        .Option("delimiter", "\t")
        .Csv("data/esuite/from_kibana.csv")

df.PrintSchema()

let levels = df.GroupBy([| Functions.Col("LEVEL") |]).Count()
levels.Show()

let result1: DataFrame =
    df
        .Select(
            Functions.Col("COMPONENT"),
            Functions.Col("DATACENTER"),
            Functions.Col("LEVEL"),
            Functions.Col("MESSAGE"),
            Functions
                .Concat(Functions.Col("LEVEL"), Functions.Lit(","), Functions.Col("Message"))
                .As("FULL MESSAGE")
        )
        .Filter(Functions.Col("LEVEL").NotEqual("INFO"))
        .Where("DATACENTER == 'DCR'")
        .GroupBy("COMPONENT", "DATACENTER")
        .Agg(
            Functions
                .CollectList(Functions.Col("FULL MESSAGE"))
                .Alias("FULL MESSAGES")
        )
        .WithColumn("ERRORS COUNT", Functions.Size(Functions.Col("FULL MESSAGES")))
        .OrderBy(Functions.Desc("ERRORS COUNT"))

result1.Show()

result1.Collect()
|> Seq.iter (fun row -> printfn "%A" row)

result1.Count() |> printfn "DCR errors: %d"

result1.Drop("LEVEL").Show()

df.Take(2)
|> Seq.iter (fun row -> printfn "%A" row)
