
# Acumatica-WooCommerce

In order to open the customization package with **Acumatica 2021R1 Update 4** and **Visual Studio 2019**, please follow the following instructions.

 - Install Acumatica 2021R1 Update 4 and create an Acumatica ERP instance.
 - Clone or download the 2021R104 branch to your development environment
 - Create customization project in Acumatica ERP as shown in the below image (you can have any name)
![Create a project](Images/Screenshot%202021-07-14%20124849.jpg)
 - Open the just created project by clicking on the project name
 - In the opened pop up window, you will find the menu as "Source Code", select "Open Project from Folder" option. ![enter image description here](Images/Screenshot%202021-07-14%20124950.jpg)
 - Select the "**AcumaticaWooCommercePkg\Customization**" folder from the cloned or downloaded location. Then click ok, and continue to load the customization into Acumatica ERP.![enter image description here](Images/Screenshot%202021-07-14%20125100.jpg)
 - Open Visual Studio 2019, and open the solution from the root of the 2021R104 branch mapped location. ![enter image description here](Images/Screenshot%202021-07-14%20141940.jpg)
 - Reference **dll**s shows below from the installed Acumatica ERP's bin folder. ![enter image description here](Images/Screenshot%202021-07-14%20125749.jpg)
 - Add the installed Acumatica Instance as an existing web site to the solution, then add reference of the **PX.Commerce.WooCommerce** to the linked web site.
 ![enter image description here](Images/Screenshot%202021-07-14%20125818.jpg)
![enter image description here](Images/Screenshot%202021-07-14%20130306.jpg)
![enter image description here](Images/Screenshot%202021-07-14%20130351.jpg)
 - Build **PX.Commerce.WooCommerce**
 - Go back to the Acumatica Customization project and publish it. ![enter image description here](Images/Screenshot%202021-07-14%20130552.jpg)
![enter image description here](Images/Screenshot%202021-07-14%20131458.jpg)
![enter image description here](Images/Screenshot%202021-07-14%20131544.jpg)
![enter image description here](Images/Screenshot%202021-07-14%20132505.jpg)
