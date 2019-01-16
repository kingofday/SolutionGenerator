
### Requirements

* Visual Studio 2017

### Usage
```
1- add your projects to solution, except "Generate" folder projects, others not required.
2- close all of other visual studio windows
3- set project "ProjectSelector"  as start up project and run it(ctrl+F5)
4- after that an win form pop ups and you can select proejcts you want to be in your new solution.
5- set project "SolutionGenerator"  as start up project and run it.(ctrl+F5)
6- after that a new visual studio would be opened and you can see a new type of project with name "Kingofday Solution Generator".
```

### Options

| option | type | desc |
| --- | --- |--- |
|  url | string |  url of server api for sending each file seperatly
| maxFileCount | int | maximum number of files to upload, default is 10 |
| maxFileSize | int | maximum size of each file in MB, default is 5 |
| extentions | string | extentions of files like "image/*,application/pdf", default is "*" |
| checkedIcon | string | icon class used for check icon, default is "zmdi zmdi-check" |
| errorIcon | string | icon class used for error icon, default is "zmdi zmdi-close" |

### Some Points

* each file will be sent by key "file"
* its better to wrap button in a div with class "col-x(>3)"
* server reponse should be in json format with this props
* 1- IsSuccesssful
* 2- Message: message if there is an error
* not forget to include css file of font your using

### schema

![alt text](assets/exp2.png)
