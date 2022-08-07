
## Setup spark and .NET for Spark

### Download

  - Hadoop
    https://archive.apache.org/dist/hadoop/common/hadoop-3.2.4/hadoop-3.2.4.tar.gz

  - Spark
  https://archive.apache.org/dist/spark/spark-3.2.0/
  https://archive.apache.org/dist/spark/spark-3.2.0/spark-3.2.0-bin-hadoop3.2.tgz

  - .NET for Apache Spark v2.1.1
    https://github.com/dotnet/spark/releases
    https://github.com/dotnet/spark/releases/download/v2.1.1/Microsoft.Spark.Worker.netcoreapp3.1.osx-x64-2.1.1.zip

### Setup environment variables

```shell
HADOOP_HOME="/Users/antonelpazargic/Downloads/Spark/hadoop-3.2.4"
SPARK_HOME="/Users/antonelpazargic/Downloads/Spark/spark-3.2.0-bin-hadoop3.2"
DOTNET_WORKER_DIR="/Users/antonelpazargic/Downloads/Spark/Microsoft.Spark.Worker-2.1.1"
PATH="$PATH:$HADOOP_HOME/bin:$SPARK_HOME/bin"
```

## Get/build the `Apache Spark Scala extensions layer` jar

[dotnet spark](https://docs.microsoft.com/en-us/dotnet/spark/how-to-guides/windows-instructions#build-net-for-apache-spark-scala-extensions-layer)

- Requirements to build `Apache Spark Scala extensions layer`
```text
sdk use java 8.0.265-zulu
sdk use maven 3.6.3
sdk use scala 2.12.10
```

### Debug Spark
- Create a shell file `spark-debug.sh` and run it

```shell
  spark-submit \
  --class org.apache.spark.deploy.dotnet.DotnetRunner \
  --master local \
  jars/microsoft-spark-3-2_2.12-2.1.1.jar \
  debug
```
 where the jar file is pointing to
```shell
/${path_to_microsoft_spark}/src/scala/microsoft-spark-3-2/target/microsoft-spark-3-2_2.12-2.1.1.jar
```
path_to_microsoft_path is the clone of the [dotnet spark](https://github.com/dotnet/spark/tree/main/src/scala)


### Put resources (csv) to Hadoop HDFS

```
hdfs dfs -mkdir -p sink/gdelt/gkg/2015/02/21
hdfs dfs -put source/20150218230000.gkg.csv  sink/gdelt/gkg/2015/02/21
```

__Notes:__
  1. Pay attention that Spark Session looks for resources based on where spark-submit command is started.
    - Relatively a path is the current directory the spark-submit command was started
    - Absolutely it is absolute on the machine the spark-submit was started.

### hdfs dfs commands

- hdfs dfs -ls
- hdfs dfs -lsr
- hdfs dfs -du

[hdfs dfs](https://hadoop.apache.org/docs/r2.6.1/hadoop-project-dist/hadoop-common/FileSystemShell.html)