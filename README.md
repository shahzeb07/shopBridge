--About shopBridge

This is a project for a shop where you can view, add, edit or delete an item.
In this project, API has been used to fetch the data from the database and to add it.
API calls have been done from the Jquery, removes extra call from the controller.

**Files
1. APIs code can be found in the Controller folder.
2. I have used DTOs to avoid direct calls from the API, can be found in the DTOs folder.
3. ViewModels are also used and can be found in the ViewModels folder.
4. The Mapping Profiles file, used for Mapping DTOs with Domain Models, can be found in App_Start folder.

How to run it:
1. Run the project
2. Go to items, you'll get the list of items
  a. You can sort the items according to any property(Sorting).
  b. You can type the name of any item or its property you'll find that item(Searching).
  c. If the items are more than 10, you can adjust the number of items displayed on the first page(Pagination).
3. You'll find the buttons to add or delete the item.
4. You can also view the item by clicking on the item's hyperlink. You will find the button to edit that particular item.
