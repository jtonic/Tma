# Concurrency, Parallelism, and Asynchrony

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

## Deadlock
    This case occurs when two or more threads are blocked forever, waiting for each other. 
    Especially whey they acquaire locks in different order.
    Philosopher's dining problem is a classic example of deadlock.

## Livelock
    Livelock is a situation where two or more threads keep on changing their state in response to the other threads.
    Two vehicles on a narrow bridge.

## Starvation
    Starvation is a situation where a thread is unable to gain regular access to shared resources and is unable to make.
    A popular case is 

## Safe Publication
    Safe publication is a technique to ensure that an object is properly constructed and visible to other threads.
    In C# safe publication can be achieved by using class constructor, static constructor, and volatile keyword.

## Thread Synchronization

## Race Condition
   Race condition occurs when two or more threads access shared data and try to change it at the same time.
   This can be prevented by using locks, semaphores, and other synchronization techniques.

## Time sliced thread scheduling
The scheduler gives each thread a small time slice to execute its task. When the time slice is over, the scheduler moves to the next thread.

## Cooperative multitasking
The scheduler relies on the threads to give up control of the CPU when they are done with their task.

## Preemptive multitasking
The scheduler can interrupt a thread and give control to another thread.

## Thread Priority
The priority of a thread determines how much CPU time the thread gets.


## Thread

  - Platform (native) Thread - is a thread that is managed by the operating system.
      Created with C# `Thread` class.
  - Managed Thread - is a thread that is managed by the .NET runtime.
  - Thread Pool - is a collection of worker threads that are available for executing tasks.
  - Background Thread - is a thread that does not keep the application running.
  - Foreground Thread - is a thread that keeps the application running.
  - Virtual Thread - is a thread that is not managed by the operating system. In C# virtual threads are managed by the .NET runtime.

## Threads Pool
   Threads pool is a collection of worker threads that are managed by the .NET runtime, that can be reused for multiple tasks.

## Thread Scheduler

## Thread Safety

## ThreadLocal

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

## Synchronized collections

- BlockingCollection
- ConcurrentBag
- ConcurrentDictionary
- ConcurrentQueue
- ConcurrentStack
