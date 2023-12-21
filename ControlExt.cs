    static class ControlExt
    {
        public static void ClearAllTextInControls(this Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1; // Clear selected item
                }
                else if (control is DataGridView dataGridView)
                {
                    if (dataGridView.DataSource != null) { dataGridView.DataSource = null; }
                    dataGridView.Rows.Clear(); // Clear rows in DataGridView
                    dataGridView.Columns.Clear();
                }
                // Add additional conditions for other control types as needed

                // Recursively clear text in nested controls if the control is a container
                if (control.HasChildren)
                {
                    ClearAllTextInControls(control);
                }
            }
        }
    }
