# AP2-FlightSimulator-WPFApp-ControllerAndRouteDisplay
Second year second semester- "Advanced programming 2" course- WPF App- Controller(interpreter and joystick) and a flight board that displays the route of the current flight

<p float="left">
  <img src="https://user-images.githubusercontent.com/45766976/115541518-e3cc7e80-a2a7-11eb-9769-ef174c7efbd3.jpg">
   <img src="https://user-images.githubusercontent.com/45766976/115541651-0eb6d280-a2a8-11eb-8fdd-95a1a3544e42.jpg" width="330">
  <img src="https://user-images.githubusercontent.com/45766976/115541516-e333e800-a2a7-11eb-8f3e-370466634757.jpg" width="300">
</p>

In this project, we built a GUI (WPF application), which allows us to control manually and automatically an aircraft on the FlightGear simulator, and showing its route on a graph-like monitor, using the [MVVM architecture](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel), Client-Server architecture, and parallel programming.<br/><br/>

We set up 2 TCP communication channels built into our code as follows:<br/>
* **Commands Channel** - in this channel, we connect as a client to the flight simulator which serves as a server. In this channel we send basic set commands to the flight simulator.<br/><br/>
* **Info Channel** - in this channel, the simulator connects as a client to our code, and sends the data about the plane. The data is defined in the [generic_small.xml](https://github.com/YamitCohenTsedek/flight-simulator-desktop-app/blob/master/generic_small.xml) file.<br/>
Thus, we have created a server that listens to the aircraft data, and in particular to the lon & lat values.<br/><br/>

The plane can be flown in 2 methods:<br/>
* **Manually** - we have a joystick with which we can set the values of the aileron, elevators, rudder and throttle. Any change in the joystick passes the appropriate set command in the Commands channel.<br/><br/>
* **Automatically** - we have a field for writing set commands. After entering the commands, we can send them in the Command channel.<br/><br/>


### Flight monitor component
In this component, there are 2 buttons:<br/> 
* **Connect button** - a button that connects to both the Commands channel and the Info channel.<br/>

* **Settings button** - this button allows us to change the settings related to operating the system. This window allows us to change the settings of the server's IP address as well as change the port communication channels. These settings are saved in the [App.config](https://github.com/YamitCohenTsedek/flight-simulator-desktop-app/blob/master/FlightSimulator/App.config) file. We got the [ApplicationSettingsModel.cs](https://github.com/YamitCohenTsedek/flight-simulator-desktop-app/blob/master/FlightSimulator/Model/ApplicationSettingsModel.cs) class which knows how to read these settings and link them to suitable Properties. After changing the IP & port addresses, this data will be saved (however, the reconnection of the communication channels will take place only after pressing the Connect button again or restarting the system).<br/><br/>

In the flight screen, appears a graph-like monitor. In this graph we show the flight route of our aircraft. The flight route is determined by the data sent in the Info channel, from which we want to sample the lat & lon values and display them in the graph (the UserControl called FlightBoard.xaml allows scrolling the graph back and forth, so that there is no fear that the aircraft will go beyond the limits of the display).<br/> 
The route shown is the route taken by the aircraft.<br/><br/>

### Control monitor
In this monitor we have 2 control options, the transition from one option to another is by using TabControl.<br/>
* **Manual control** - in this component we implemented a joystick with which we can determine the values of aileron, elevators, rudder, and throttle. The values of the throttle and the rudder are determined using a slider which contains values in the range [-1,1].
The values of the aileron and the elevators are determined by the Joystick Control, which is in the Joystick.xaml file. Any change of one of these values leads to the values of the aircraft being updated by the Commands channel.<br/>

* **Automatic control** - this component contains a TextBox control that allows us to write Set commands in the Commands channel.
The commands are interpreted using [the interpreter we previously wrote](https://github.com/israelElad/AP1-FlightSimulator-Interpreter).![ex2 git pic3](https://user-images.githubusercontent.com/45766976/115541639-0a8ab500-a2a8-11eb-83a4-70ba67bced49.jpg)

This control contains 2 buttons:<br/><br/> 
<tab><tab> * **OK button** - executes all the commands in the Commands channel one by one, when between each command there is a delay of 2 seconds so that we can see it in the simulator (this does not mean that the monitor is frozen while sending the information).<br/>
We assume that the OK button would be pressed only once for each commands sending, and there would be no simultaneous sending of 2 different sets of commands.<br/><br/> 
 <tab><tab> * **Clear Button** - Cleans the command screen. When the user enters commands that have not yet reached the server, the background of the TextBox will be painted red bright, and after sending the commands - it will back to white.<br/><br/><br/>


### Watch on a friend's YouTube channel:
[![](https://user-images.githubusercontent.com/45918740/98307490-87fa8b80-1fce-11eb-9b4e-2cb9e0f6bba6.jpg)](https://youtu.be/HGgdXiNtY_E)
