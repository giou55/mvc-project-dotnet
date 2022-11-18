A view is an HTML template with embedded Razor markup. 
Usually, view files are grouped into folders named for each of the app's controllers. 
The Home controller is represented by a Home folder inside the Views folder.

***Layouts***provide consistent webpage sections and reduce code repetition.
Partial views reduce code duplication by managing reusable parts of views.
View components are similar to partial views in that they allow you to reduce 
repetitive code, but they're appropriate for view content that requires code to 
run on the server in order to render the webpage.

@{
    ViewData["Title"] = "About";
}
<h2>@ViewData["Title"].</h2>