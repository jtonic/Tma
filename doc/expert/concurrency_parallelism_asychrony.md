# Concurrency, Parallelism, and Asynchrony

## Basics concepts

1. Concurrency

2. Parallelism

3. Asynchrony

4. Synchronization and Locking (for sharing resources in multi-threaded environments) 

    In C# there are the following constructs for synchronization and locking:
    - `ReaderWriterLock` class
    - `lock` statement
    - `Monitor` class
    - `Mutex` class
    - `Semaphore` class

## Advanced concepts

1. Race Condition
   It occurs when two or more threads access shared data and try to change it at the same time.
   This can be prevented by using locks, semaphores, and other synchronization techniques.

2. Deadlock
    This case occurs when two or more threads are blocked forever, waiting for each other. 
    Especially whey they acquaire locks in different order.
    Philosopher's dining problem is a classic example of deadlock.

3. Livelock
    Is a situation where two or more threads keep on changing their state in response to the other threads.
    Two vehicles on a narrow bridge.

4. Starvation
    Is a situation where a thread is unable to gain regular access to shared resources and is unable to make.

5. Safe Publication
    Is a technique to ensure that an object is properly constructed and visible to other threads.
    In C# safe publication can be achieved by using class constructor, static constructor, and volatile keyword.

## Threads Scheduling

1. Time sliced thread scheduling
The scheduler gives each thread a small-time slice to execute its task. When the time slice is over, the scheduler moves to the next thread.

2. Cooperative multitasking
The scheduler relies on the threads to give up control of the CPU when they are done with their task.

3. Preemptive multitasking
The scheduler can interrupt a thread and give control to another thread.

4. Thread Priority
The priority of a thread determines how much CPU time the thread gets.

## Thread

  - Platform (native) Thread - is a thread that is managed by the operating system.
      Created with C# `Thread` class.
  - Managed Thread - is a thread that is managed by the .NET runtime.
  - Thread Pool - is a collection of worker threads that are available for executing tasks.
  - Background Thread - is a thread that does not keep the application running.
  - Foreground Thread - is a thread that keeps the application running.
  - Virtual Thread - is a thread that is not managed by the operating system. In C# virtual threads are managed by the .NET runtime.

  Threads in java:

  - Platform (native) Thread - is a thread that is managed by the operating system.
  - Managed Thread - is a thread that is managed by the JVM.
  - Virtual Thread - Loom project

## Memory model

   Memory model is to enable thread communication
   - [Memory model in C# and .NET documentation](https://learn.microsoft.com/en-us/archive/msdn-magazine/2012/december/csharp-the-csharp-memory-model-in-theory-and-practice#thread-communication-patterns)
   - Locking
   - Volatile

## Building blocks for asynchronous programming in C#:

- Interlocked (Atomic operations like AtomicXxx in java)
- Barrier
- MemoryBarrier
- Monitor
- Mutex
- Semaphore
- Volatile
- Interlocked
- ReaderWriterLock
- Lock
- ThreadLocal

## Concurrent collections

Java package: `java.util.concurrent` 

Java Concurrent Collections
- ConcurrentHashMap
- ConcurrentMap
- ConcurrentLinkedQueue
- ConcurrentLinkedDeque
- CopyOnWriteArrayList
- CopyOnWriteArraySet

## Threads vs Processes

- Threads share the same memory space, while processes have separate memory spaces
- Threads are lightweight compared to processes
- Threads are easier and faster to create than processes.
- Threads are used for small tasks, while processes are used for more heavyweight tasks.
- Threads are easier to terminate than processes.
- Threads are easier to synchronize than processes.
- Threads are easier to communicate with than processes.
- Threads are easier to debug than processes.

## Inter process communication techniques

- SOA - RESTful Services, SOAP Web Services
- Message Queues
- Pipes
- Sockets
- File Mapping
- RPC (Remote Procedure Call)
- DCOM (Distributed Component Object Model)
- CORBA (Common Object Request Broker Architecture)

## Continuous Passing Style (CPS) in Kotlin

- CPS is a programming style where the result of a function is passed as a parameter to another function.
- In Kotlin, CPS can be achieved using higher-order functions and lambda expressions.
- Syntax
  - `suspend` keyword
  Builder functions:
    - `runBlocking` function
    - `launch` function
    - `async` function
    - `await` function
    - `withContext` function
  API main types:
  - `CoroutineScope` interface
  - `CoroutineContext` interface
  - `CoroutineDispatcher` interface

## Structure Concurrency
    It is about:
    - child coroutines are cancelled when parent coroutine is cancelled
    - if a child coroutine fails, the parent coroutine is notified
    - if a parent coroutine fails, all child coroutines are cancelled
    in the context of:
    - exception thrown in a coroutine
    - cancellation of a coroutine

## Other Kotlin coroutines features

    - Flow 
        - is a cold asynchronous stream that sequentially emits values and completes normally or with an exception.
    - Channels
        - is a hot asynchronous stream that can be used to send and receive values between coroutines.  

    - Actors (decommisioned)

## Actor Model in Akka

    It is about creating actors that communicate with each other by sending messages.
    Main concepts:
    - ActorSystem
    - Actor
    - ActorRef
    - ActorPath
    - ActorSelection
    - Message
    - ActorContext
    - Actor supervision
    - Regarding the threads and scheduling of actors, 
        Akka uses a dispatcher to manage the execution of actors
        the default the dispacher is a fork-join pool
