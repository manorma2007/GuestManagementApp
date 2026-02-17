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
<img width="949" height="475" alt="image" src="https://github.com/user-attachments/assets/b1d8e73d-a351-42d8-8668-08262b3c94d5" />
<img width="949" height="440" alt="image" src="https://github.com/user-attachments/assets/c193f7f2-e325-441e-9fe3-7c47bb767a3c" />

<h2><span style="text-decoration: underline;">API endpoints - Brief description of each endpoint with example&nbsp;</span>span></h2>
<p>API should now be running locally. Open your web browser or API testing tool and access the following URL:</p>
<ol>
<li><strong>POST</strong> - https://localhost:{port}/api/reservations - Create a new reservation</li>
  <p>&nbsp;</p>
  <img width="949" height="470" alt="image" src="https://github.com/user-attachments/assets/2690d62c-048f-403a-9481-2cc4c3c28135" />
  <p>&nbsp;</p>
  <img width="947" height="470" alt="image" src="https://github.com/user-attachments/assets/57cd81ab-4799-46d5-b496-5f104039ba4e" />
  <p>&nbsp;</p>
<img width="929" height="467" alt="image" src="https://github.com/user-attachments/assets/fad878c4-c24b-4c25-8274-b9e606acd5ff" />
<p>&nbsp;</p>
<li><strong>GET</strong> - https://localhost:{port}/api/reservations - List all reservations</li>
<p>&nbsp;</p>
  <img width="940" height="477" alt="image" src="https://github.com/user-attachments/assets/45cf78c5-0d23-4d0a-88ef-2b094b2830ed" />
<p>&nbsp;</p>
  <img width="935" height="470" alt="image" src="https://github.com/user-attachments/assets/45eaa1db-9386-4b25-9ba1-4ef1b8df1a88" />
  <p>&nbsp;</p>
<li><strong>GET</strong> - https://localhost:{port}/api/reservations/{id} - Get reservation by ID</li>
<p>&nbsp;</p>
  <img width="953" height="473" alt="image" src="https://github.com/user-attachments/assets/54956e19-9506-482c-a8e8-ce17ac3a9792" />
  <p>&nbsp;</p>
  <img width="940" height="474" alt="image" src="https://github.com/user-attachments/assets/48520124-ab46-4d47-97fe-558d211635ca" />
  <p>&nbsp;</p>
<li><strong>PUT</strong> - https://localhost:{port}/api/reservations/{id} - Update reservation details</li>
<p>&nbsp;</p>
  <img width="940" height="479" alt="image" src="https://github.com/user-attachments/assets/875fee92-a5fd-44e7-83b8-00d2aa5475a3" />
<p>&nbsp;</p>
  <img width="954" height="473" alt="image" src="https://github.com/user-attachments/assets/5fdd1d29-35a9-4b2e-9545-5378dfb29844" />
  <p>&nbsp;</p>
<li><strong>PATCH</strong> - https://localhost:{port}/api/reservations/{id}/check-in - Check-in a guest</li>
<p>&nbsp;</p>
  <img width="956" height="472" alt="image" src="https://github.com/user-attachments/assets/3b92ba36-2711-4792-9c74-1e14681a97a3" />
  <p>&nbsp;</p>
<li><strong>PATCH</strong> - https://localhost:{port}/api/reservations/{id}/check-out - Check-out a guest</li>
<p>&nbsp;</p>
<img width="952" height="469" alt="image" src="https://github.com/user-attachments/assets/b0374955-a04d-4445-b40a-502026893d84" />
<p>&nbsp;</p>
<li><strong>DELETE</strong> - https://localhost:{port}/api/reservations/{id} - Cancel a reservation&nbsp; &nbsp;</li>
<p>&nbsp;</p>
  <img width="930" height="436" alt="image" src="https://github.com/user-attachments/assets/cb0421a6-80f7-454b-a633-c1f54da257b0" />
</ol>
<h2>Run Test Case&nbsp;</h2>
<p>Run the test cases project from Tests project</p>
<p>&nbsp;</p>
<img width="922" height="425" alt="image" src="https://github.com/user-attachments/assets/06661592-8fcc-40d8-89bf-5f900d07fea8" />
<p>&nbsp;</p>
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
<li>Improve Logging implementation</li>
<li>Performence improvement and code quality improvement</li>
</ol>&nbsp;
<p>&nbsp;</p>

