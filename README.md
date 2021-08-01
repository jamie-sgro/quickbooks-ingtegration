# QuickBooks Integration

The Invoice Importer by Sangwa is a desktop application integrated with the accounting software QuickBooks to automate the client invoicing processes.
This application has reduced manual entry times by up to 94%, by recognizing common patterns in invoice processing and providing a clean user interface to processing invoices in bulk.

The code base is in C#, with a SQLite database, a XAML user interface, and integrates with the QuickBooks SDK to import staffing placement data and create invoices. Client data has been scrubbed and the images below provide a snapshot of a synthetic data set that is similar to the one in use currently.

## Example Workflow

To begin, we select the ‘Import’ tab and click ‘Select File’ and import a .csv file with invoices that need to be sent. In this example, we have two customers (Customer1 and Customer2) with various line items to be processed.

![import](https://github.com/jamie-sgro/quickbooks-ingtegration/blob/master/images/import.png?raw=true)

To ensure the data from the imported .csv file can properly map with the data users enter into excel, we offer a ‘Customer’ and ‘Item’ tab. In these tabs, users can specify customer rules. For example, in the below image, we’ve set a rule for the customer named Customer2 to change their payment terms to Net 15. The last customer has a custom rule to add a message at the end of their invoice thanking them for their business.

![customer](https://github.com/jamie-sgro/quickbooks-ingtegration/blob/master/images/customer.png?raw=true)



If, for example, the line items on an invoice don’t match exactly what users have in QuickBooks, the ‘Item’ tab allows custom rules as well. In the below example, the line item imported from the .csv file is too long, so the user has set up a rule to replace this long item name with, literally “A shorter item name”.

![item](https://github.com/jamie-sgro/quickbooks-ingtegration/blob/master/images/item.png?raw=true)

Once all custom rules have been specified, the data is ready to be imported. In the ‘QuickBooks’ tab, users can map the names of the column headers in the .csv file with fields in QuickBooks. In the below example, Customer, Template, Item, and Quantity have all been mapped to .csv headers with the same name. Additionally, the user has specified that they would like to have all payment terms set to ‘Net 30’ by using the rightmost column, and additionally, specified that all line items should have the text written in the description row’s rightmost column. Remember that Customer2 has a custom rule specified so that their payment terms will be set to ‘Net 15’ upon import.

![quickbooks](https://github.com/jamie-sgro/quickbooks-ingtegration/blob/master/images/quickbooks.png?raw=true)

The below image comes from the QuickBooks application itself, and indicates that both invoices were imported properly. Note that the due date for Customer2 reflects the change in payment terms from Net 30 to Net 15, per the new customer rule set in the ‘Customer’ tab.

![imported-invoices](https://github.com/jamie-sgro/quickbooks-ingtegration/blob/master/images/imported-invoices.png?raw=true)

## 0.7.0 Update, New Plugin Architecture!

We're is excited to announce the addition of a new Plugin Manager, allowing external developers to extend the core functionality of the Invoice Importer. Found in the ‘Tools’ section, the Plugin Manager lets users import new features and select which plugins they’d like to use. In the below example, the client has added a plugin that simply combines two columns and creates a new column called ‘FullName’.

![plugin](https://github.com/jamie-sgro/quickbooks-ingtegration/blob/master/images/plugin.png?raw=true)
