<h2><span style="text-decoration: underline;">How to run - Setup and run instructions</span></h2>
<p><strong>Code Setup :</strong></p>
<ul>
<li>Clone or download the repository from : 
  <a href="https://github.com/manorma2007/GuestManagementApp.git">https://github.com/manorma2007/GuestManagementApp.git</a></li>
<li>Open project in Visual studio<br />Set as startup Project to "GuestManagement.API"</li>
</ul>
<p><strong>DB Setup :</strong></p>
<ul>
<li>Setup connection string into appsettings.json file for your SQL DB</li>
<li>Go to package manager console</li>
<li>Select "GuestManagement.Infrastructure" Project from drop down</li>
<li>Run the command to add migration if not exists : Add-Migration &lt;Migration Name&gt;</li>
<li>Run the db update command : Update-Database</li>
</ul>
<p>Clean, build and run application to access the endpoints.</p>
<p><strong>NOTE :</strong>&nbsp;if required please include or update required NuGet packages and project reference if any one missing or not working.</p>
<h2><span style="text-decoration: underline;"><strong>Access the API Endpoints:</strong></span></h2>
<p>API endpoints - Brief description of each endpoint with example&nbsp;</p>
<p>API should now be running locally. Open your web browser or API testing tool and access the following URL:</p>
<ol>
<li><strong>POST</strong> - https://localhost:{port}/api/reservations - Create a new reservation</li>
<li><strong>GET</strong> - https://localhost:{port}/api/reservations - List all reservations</li>
<li><strong>GET</strong> - https://localhost:{port}/api/reservations/{id} - Get reservation by ID</li>
<li><strong>PUT</strong> - https://localhost:{port}/api/reservations/{id} - Update reservation details</li>
<li><strong>PATCH</strong> - https://localhost:{port}/api/reservations/{id}/check-in - Check-in a guest</li>
<li><strong>PATCH</strong> - https://localhost:{port}/api/reservations/{id}/check-out - Check-out a guest</li>
<li><strong>DELETE</strong> - https://localhost:{port}/api/reservations/{id} - Cancel a reservation&nbsp; &nbsp;</li>
</ol>
<h2>Run Test Case&nbsp;</h2>
<p>Run the test cases project from Tests project</p>
<p>&nbsp;</p>
<h2>What you'd improve - With more time, what would you add/change?</h2>
<p>If get more time to work on it, there is significant scope of improvement.</p>
<ol>
<li>Improve validation. Ex. If room is already booked for the selected date then we can return error message i.e. :&nbsp;"Room already booked for this date. Please book other room or choose another date".</li>
<li>Few more validation can be apply on Check In &amp; Check Out Date. i.e. : checkout date should not be less then Check in date.</li>
<li>Maintain date time format consistency throw-out the application.</li>
<li>Improve Exception handling</li>
<li>Add filtering, shorting paging&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</li>
<li>Implement in-memory caching</li>
<li>Improve and include more test case. Write test case for all the layers.&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</li>
<li>Improve Logging</li>
</ol>&nbsp;
<h2>Design decisions - Why you structured the code the way you did</h2>
<p>&nbsp;<strong data-start="104" data-end="126">Clean Architecture</strong> is a way to organize your project so that it is:</p>
<ul data-start="177" data-end="289">
<li data-start="177" data-end="199">
<p data-start="179" data-end="199">Easy to maintain</p>
</li>
<li data-start="200" data-end="218">
<p data-start="202" data-end="218">Easy to test</p>
</li>
<li data-start="219" data-end="239">
<p data-start="221" data-end="239">Easy to change</p>
</li>
<li data-start="240" data-end="289">
<p data-start="242" data-end="289">Independent of database, UI, and frameworks</p>
</li>
<li data-start="424" data-end="451">
<p data-start="426" data-end="451">Separate responsibilities</p>
</li>
<li data-start="452" data-end="474">
<p data-start="454" data-end="474">Avoid tight coupling</p>
</li>
<li data-start="475" data-end="495">
<p data-start="477" data-end="495">Make code scalable</p>
</li>
<li data-start="496" data-end="521">
<p data-start="498" data-end="521">Follow SOLID principles</p>
</li>
<li data-start="522" data-end="569">
<p data-start="524" data-end="569">Make project professional (Professional structure)</p>
</li>
<li data-start="522" data-end="569">
<p data-start="524" data-end="569">Used in real companies</p>
</li>
</ul>
<h2>&nbsp;</h2>
<p>&nbsp;</p>

