# TableConnector
Below is an example of how it could look like in a Form.cs file

```
public partial class Form1 : Form
    {
        TableConnector tableConn = new TableConnector();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            string sqlS1 = "SELECT * FROM Bolig";
            dataGridView1.DataSource = tableConn.tableBinder(sqlS1);

            string sqlS2 = "SELECT * FROM Kunde";
            dataGridView2.DataSource = tableConn.tableBinder(sqlS2);
        }
    }
```
Creation of an object of the class:

    TableConnector tableConn = new TableConnector();

Executing a SELECT SQL query in the db to display data in dataGridView1

    dataGridView1.DataSource = tableConn.tableBinder(sqlS1)
Keep in mind that dataGridView1 refers to the gridView in that Form.cs file not in Form2.cs (for example)
