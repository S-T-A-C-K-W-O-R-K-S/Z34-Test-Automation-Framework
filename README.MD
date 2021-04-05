# Z34 > Query Hub
Enterprise-Grade .NET-Based Test Automation Framework

# build
* > docker build -t z34:1.0.0 .

# run
| Platform | Example Command                                             |
| :------: | :---------------------------------------------------------- |
| UNIX     | docker run -it --name z34 --volume C:\Z34:/out z34:1.0.0    |
| Windows  | docker run -it --name z34 --volume /home/Z34:/out z34:1.0.0 |

NOTE: On Windows, Resource File Sharing In Docker May Need To Be Enabled For Volumes To Work

# debug
* > docker export z34 > z34.tar
* > docker system prune --all --volumes

# overridable environment variables
| Name           | Usage                                                                            | Default Value               |
| :------------: | -------------------------------------------------------------------------------: | :-------------------------- |
| Host           | defines the IP address of the system under test                                  | value from test run profile |
| TestRunProfile | defines which test run profile to be used from the configuration file            | "Z34 Default"               |
| TestRunName    | defines the name of the directory where the test run results will be stored      | test run timestamp          |
| TestResultsDir | defines the fully qualified path where results from all test runs will be stored | solution directory          |

Value Priority:
* environment variable
* configuration file variable
* hard-coded default value

NOTE: All Environment Variables Are Optional
