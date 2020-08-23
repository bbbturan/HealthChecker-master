<h1>Health Checker Project</h1></br></br>

<h2>Summary</h2></br>
<p>This project provide that create a url repository for each user. Users add urls via Health Checker web application to system. Each url records have name, url string, </br>
interval and userId. Application user can manage url settings.(Change url name, url string and checking interval) After adding, program start to check urls in defined period </br>
and if something getting wrong return error log and send information mail to user.</p>
</br></br>
<h2>Settings</h2>
</br>
<h3>Database Settings</h3></br>
<p>First of all set your own connection settings in <i>'HealthChecker.DataAccess/ApplicationContext'</i> file.</p></br>
<h3>Services Settings</h3></br>
<h4>Mail Service</h4></br>
<p>You have to set your own mail informations and smtp provider. You can file these settings in the <i>"HealthChecker.API/Services/MailService"</i> file.</p>

