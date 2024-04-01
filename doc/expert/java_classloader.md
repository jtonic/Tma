# Java classloaders

## Classloader hierarchy (for normal java applications)

- `Bootstrap classloader` - loads JDK classes from `jre/lib/rt.jar`

- `Extension classloader` - loads JDK classes from `jre/lib/ext/*.jar`

- `System classloader` - loads classes from classpath

## SpringBoot fatjar classloaders

The structure of the springboot fatjar is as follows:

+-META-INF
 |  +-MANIFEST.MF
 +-org
 |  +-springframework
 |     +-boot
 |        +-loader
 |           +-<spring boot loader classes>
 +-BOOT-INF
    +-classes
    |  +-<project classes>
    +-lib
       +-<libraries required for the project>

When a Spring Boot application starts, the following classloaders are used:

- `Bootstrap ClassLoader` Loads the core Java libraries. This is the same as in any Java application.

- `Extension classloader` - loads JDK classes from `jre/lib/ext/*.jar`

- `System ClassLoader` Loads the Spring Boot loader classes from the `org/springframework/boot/loader directory`.

- `LaunchedURLClassLoader` A custom classloader used by Spring Boot. It loads the application classes from BOOT-INF/classes and the libraries from BOOT-INF/lib. This classloader is a child of the System ClassLoader.

The LaunchedURLClassLoader is the classloader that actually loads your application, and it does so in an isolated manner. This means that the application's classes and libraries are loaded independently of the system classpath, which can help to avoid version conflicts between your application and the system's Java environment.
