using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Encryption_and_decryption_V1
{
public partial class Form1 : Form
{
string sss, ss, k, m;

public Form1()
{
InitializeComponent();
}

private void button4_Click(object sender, EventArgs e)
{
int n, d, t = 0;
int f, j;

char[] message = m.ToCharArray();
char[] key = k.ToCharArray();
char[] alf = { 'а','б','в','г','д','е','ё','ж','з','и','й','к','л','м','н','о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я',' '};

for (int i = 0; i < message.Length; i++)
{
for (j = 0; j < alf.Length; j++)
{
if (message[i] == alf[j]) { break; }
}
if (j != 34)
{
n = j;
if (t > key.Length - 1) { t = 0; }

for (f = 0; f < alf.Length; f++)
{
if (key[t] == alf[f])
{
break;
}
}
t++;

if (f != 34)
{
d = n + f;
}
else
{
d = n;
}

if (d > 33)
{
d = d - 34;
}
message[i] = alf[d];
}
}
ss = new string(message);
textBox2.Text = ss;
}

private void button2_Click(object sender, EventArgs e)
{
int n, d, t = 0;
int f, j;

char[] message = m.ToCharArray();
char[] key = k.ToCharArray();
char[] alf = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', ' ' };

for (int i = 0; i < message.Length; i++)
{
for (j = 0; j < alf.Length; j++)
{
if (message[i] == alf[j]) { break; }
}
if (j != 34)
{
n = j;
if (t > key.Length - 1) { t = 0; }

for (f = 0; f < alf.Length; f++)
{
if (key[t] == alf[f])
{
break;
}
}
t++;

if (f != 34)
{
d = n - f + alf.Length;
}
else
{
d = n;
}

if (d > 33)
{
d = d - 34;
}
message[i] = alf[d];
}
}
sss = new string(message);
textBox2.Text = sss;
}

private void button1_Click(object sender, EventArgs e)
{
OpenFileDialog o = new OpenFileDialog();
o.Filter = "txt files (*.txt)|*.txt|All files(*.*)|*.*";
if (o.ShowDialog() == DialogResult.OK)
{
textBox1.Text = File.ReadAllText(o.FileName, Encoding.GetEncoding(1251));
m = File.ReadAllText(o.FileName, Encoding.GetEncoding(1251));
}
else
{
MessageBox.Show("Ошибка. Файл не загружен.");
}

}
private void button6_Click(object sender, EventArgs e)
{
OpenFileDialog o = new OpenFileDialog();
o.Filter = "txt files (*.txt)|*.txt|All files(*.*)|*.*";
if (o.ShowDialog() == DialogResult.OK)
{
textBox3.Text = File.ReadAllText(o.FileName, Encoding.GetEncoding(1251));
m = File.ReadAllText(o.FileName, Encoding.GetEncoding(1251));
}
else
{
MessageBox.Show("Ошибка. Файл не загружен.");
}
}

private void button3_Click(object sender, EventArgs e)
{
if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
return;
string filename = saveFileDialog1.FileName;
System.IO.File.WriteAllText(filename, ss, Encoding.Default);
}

private void Form1_Load(object sender, EventArgs e)
{

}

private void button5_Click(object sender, EventArgs e)
{
if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
return;
string filename = saveFileDialog1.FileName;
System.IO.File.WriteAllText(filename, sss, Encoding.Default);
}

private void checkBox1_CheckedChanged(object sender, EventArgs e)
{
CheckBox check = (CheckBox)sender;
if (check.Checked == true)
{
button6.Enabled = false;
textBox3.ReadOnly = false;
}
else
{
button6.Enabled = true;
textBox3.ReadOnly = true;
}
}

private void textBox3_TextChanged(object sender, EventArgs e)
{
k = Convert.ToString(textBox3.Text);
}

}
}
