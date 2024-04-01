# Java Garbage Collectors

Java garbage collectors are part of the Java Virtual Machine (JVM) that manage memory automatically.
They free up memory by identifying and disposing of objects that are no longer needed by the application.
Garbage collectors primarily manage the heap area

Main types of garbage collectors in Java:

1. `Serial Garbage Collector`: This is the simplest type of garbage collector.
  It works by holding all application threads, which can be inefficient for larger applications but may work well for simple command-line programs.

2. `Parallel Garbage Collector`
  It is similar to the serial collector but with multiple threads.
  It's designed for multi-core and multi-processor machines, aiming to maximize throughput by minimizing the time spent doing garbage collection.

3. `Concurrent Mark Sweep (CMS) Garbage Collector`
  This collector works by doing most of its work concurrently with the application threads to minimize pause times.
  It's suitable for responsive applications where low pause times are important.

4. `G1 Garbage Collector`
  G1 stands for "Garbage First".
  It's designed for heap sizes larger than 4GB and aims to meet garbage collection (GC) pause time goals with high probability, while achieving high throughput.

5. `Z Garbage Collector (ZGC)`
  These are low pause time garbage collectors that aim to pause times less than 10ms.


## JVM memory areas

JMM is divided into several areas:

1. `Heap`
  This is the runtime data area from which memory for all class instances and arrays is allocated.
  The heap is created on virtual machine start-up and shared among all Java Virtual Machine (JVM) threads.
  `The heap is the primary area of concern for garbage collectors.` 
  When an object is no longer referenced by any part of the program, the garbage collector considers it eligible for removal from the heap.

2. `Stack`
  `Each JVM thread has a private JVM stack, created at the same time as the thread.`
  A stack stores frames, which hold local variables and partial results, and perform dynamic linking, return values for methods, and dispatch exceptions.
  `Garbage collectors do not directly manage this area`, but they do consider stack contents when determining object reachability.

3. `Method Area`
   This is a memory area shared among all threads.
   It stores per-class structures such as runtime constant pool, field and method data, and the code for methods and constructors.
   Like the heap, it is created on JVM start-up.
   While garbage collectors do not clean up this area directly, they can indirectly affect it (for example, if a ClassLoader instance becomes unreachable, its classes can be garbage collected, which will free up space in the method area).

4. `Native Method Stack`
  This is where the JVM stores native method information. Like the JVM stack, `garbage collectors do not manage this area directly`.

5. `PC (Program Counter) Register`
  Each JVM thread has a PC Register, which contains the address of the currently executed instruction.
  If the method being executed is not native, the PC register contains the address of the JVM instruction currently being executed. `Garbage collectors do not interact with this area.`

## Heap memory areas (generations)

The Java heap memory is divided into different generations, or memory pools, to optimize garbage collection.

1. `Young Generation`
  This is where all new objects are allocated and aged.
  When the young generation fills up, this causes a `minor garbage collection`.
  Minor collections can be optimized assuming a `high object mortality rate`. The Young Generation is divided into two parts:

    - `Eden Space` The pool from which memory is initially allocated for most objects.

    - `Survivor Space`: The pool containing objects that have survived the garbage collection of the Eden Space.

2. `Old Generation`
  This is used to store long surviving objects.
  Typically, a threshold is set for young generation object and when that age is met, the object gets moved to the old generation.
  Eventually the old generation needs to be collected (this event is called a `major garbage collection`), which is often `a much larger process than the minor collections`.

3. `Permanent Generation`
  This consists of JVM metadata for the runtime classes and application methods.
  Note that this generation is removed in Java 8 and the `metaspace` is introduced.

4. `Metaspace` - Introduced in Java 8, this is where class metadata is stored.
  It is not part of the heap, but it is still managed by the garbage collector.

## Object reference types

1. `Strong Reference`
  This is the most common type of reference in Java.
  `An object with a strong reference will not be garbage collected`.

2. `Soft Reference`
  Objects with soft references are only collected when the garbage collector determines that memory is low.
  This can help prevent `OutOfMemoryError` exceptions.

3. `Weak Reference`
  Objects with weak references are collected during the next garbage collection cycle.
  This can be useful for caching, as the garbage collector will automatically remove objects that are no longer needed.
  Very popular for implementing caches.

4. `Phantom Reference`
  Objects with phantom references are collected during the next garbage collection cycle, after the garbage collector determines that their referent is no longer reachable.
