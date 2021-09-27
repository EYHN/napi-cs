
# NApi CS

Build nodejs modules with Dotnet and CSharp.


# Getting Started

1. Install templates

``` bash
$ dotnet new -i NApi.Template
```

2. Create Project

``` bash
$ mkdir foo && cd foo
$ dotnet new nodejs
```

3. Build

``` bash
$ dotnet build
```

4. Test Your Module

``` bash
$ node
> require("./bin/Debug/net6.0/osx-x64/native/module.node")
```

> PS: Replace `osx-x64` with your operating system 