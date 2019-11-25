import java.awt.*;
import java.awt.event.*;
import java.io.IOException;
import java.net.URI;

import javax.swing.*;
import javax.swing.event.*;

public class calculator extends JFrame implements ActionListener
{
JTextField jtx;
double temp,temp1,result,a;
static double m1,m2;
int k=1,x=0,y=0,z=0;
char ch;
JButton
one,two,three,four,five,six,seven,eight,nine,zero,clr,pow2,pow3,exp,off1;
JButton
plus,min,div,lg,rec,mul,eq,plmi,poin,mr,mc,mp,mm,sqrt,sin1,cos1,tan1,snh,csh,tnh;
JMenuBar bar;
JMenu view,help;

JMenuItem exit;
JMenuItem Contact_Us ;
JRadioButtonMenuItem standard,scientific;

ButtonGroup bg;
Container cont;
JPanel buttonpanel;
calculator()
{
cont=getContentPane();
cont.setLayout(new BorderLayout());

buttonpanel=new JPanel();
jtx=new JTextField();
jtx.setFont(new Font("Arial",Font.BOLD,24));
buttonpanel.add(jtx);

buttonpanel.setLayout(new GridLayout(5,4,2,2));
boolean t=true;

bar=new JMenuBar();
view=new JMenu("Calculator");
help=new JMenu("Help");

exit=new JMenuItem("Exit");
exit.addActionListener(this);
Contact_Us=new JMenuItem("Contact_Us");
Contact_Us.addActionListener(new ActionListener()
{
	   @Override
     public void actionPerformed (ActionEvent n) {
		   
		   try{
				 final URI uri = new URI("https://www.facebook.com/pages/Java-Projects/528280973960603");
				  open(uri);
				}
		catch(Exception ex)
		{
			ex.printStackTrace();}
		  }
});


view.add(exit);
help.add(Contact_Us);

bar.add(view);
bar.add(help);
setJMenuBar(bar);

mr=new JButton("MR");
mr.setBackground(Color.LIGHT_GRAY);
mr.setFont(new Font("Serif", Font.BOLD, 20));
mr.setForeground(Color.black);
buttonpanel.add(mr);
mr.addActionListener(this);

seven=new JButton("7");
seven.setBackground(Color.LIGHT_GRAY);
seven.setFont(new Font("Serif", Font.BOLD, 20));
seven.setForeground(Color.black);
buttonpanel.add(seven);
seven.addActionListener(this);

snh=new JButton("sinh");
snh.setBackground(Color.LIGHT_GRAY);
snh.setFont(new Font("Serif", Font.BOLD, 20));
snh.setForeground(Color.black);
buttonpanel.add(snh);
snh.addActionListener(this);

csh=new JButton("cosh");
csh.setBackground(Color.LIGHT_GRAY);
csh.setFont(new Font("Serif", Font.BOLD, 20));
csh.setForeground(Color.black);
buttonpanel.add(csh);
csh.addActionListener(this);

tnh=new JButton("tanh");
tnh.setBackground(Color.LIGHT_GRAY);
tnh.setFont(new Font("Serif", Font.BOLD, 20));
tnh.setForeground(Color.black);
buttonpanel.add(tnh);
tnh.addActionListener(this);

off1=new JButton("off");
off1.setBackground(Color.LIGHT_GRAY);
off1.setFont(new Font("Serif", Font.BOLD, 20));
off1.setForeground(Color.black);
buttonpanel.add(off1);
off1.addActionListener(this);




eight=new JButton("8");
eight.setBackground(Color.LIGHT_GRAY);
eight.setFont(new Font("Serif", Font.BOLD, 20));
eight.setForeground(Color.black);
buttonpanel.add(eight);
eight.addActionListener(this);
nine=new JButton("9");
nine.setBackground(Color.LIGHT_GRAY);
nine.setFont(new Font("Serif", Font.BOLD, 20));
nine.setForeground(Color.black);
buttonpanel.add(nine);
nine.addActionListener(this);
clr=new JButton("AC");
clr.setBackground(Color.LIGHT_GRAY);
clr.setFont(new Font("Serif", Font.BOLD, 20));
clr.setForeground(Color.black);
buttonpanel.add(clr);
clr.addActionListener(this);

mc=new JButton("MC");
buttonpanel.add(mc);
mc.setBackground(Color.LIGHT_GRAY);
mc.setFont(new Font("Serif", Font.BOLD, 20));
mc.setForeground(Color.black);
mc.addActionListener(this);
four=new JButton("4");
four.setBackground(Color.LIGHT_GRAY);
four.setFont(new Font("Serif", Font.BOLD, 20));
four.setForeground(Color.black);
buttonpanel.add(four);
four.addActionListener(this);
five=new JButton("5");
five.setBackground(Color.LIGHT_GRAY);
buttonpanel.add(five);
five.setFont(new Font("Serif", Font.BOLD, 20));
five.setForeground(Color.black);
five.addActionListener(this);
six=new JButton("6");
six.setBackground(Color.LIGHT_GRAY);
six.setFont(new Font("Serif", Font.BOLD, 20));
six.setForeground(Color.black);
buttonpanel.add(six);
six.addActionListener(this);
mul=new JButton("*");
mul.setBackground(Color.LIGHT_GRAY);
mul.setFont(new Font("Serif", Font.BOLD, 30));
mul.setForeground(Color.black);
buttonpanel.add(mul);
mul.addActionListener(this);

mp=new JButton("M+");
mp.setBackground(Color.LIGHT_GRAY);
mp.setFont(new Font("Serif", Font.BOLD, 20));
mp.setForeground(Color.black);
buttonpanel.add(mp);
mp.addActionListener(this);
one=new JButton("1");
one.setBackground(Color.LIGHT_GRAY);
one.setFont(new Font("Serif", Font.BOLD, 20));
one.setForeground(Color.black);
buttonpanel.add(one);
one.setBackground(Color.LIGHT_GRAY);
one.addActionListener(this);
two=new JButton("2");
two.setBackground(Color.LIGHT_GRAY);
two.setFont(new Font("Serif", Font.BOLD, 20));
two.setForeground(Color.black);
buttonpanel.add(two);
two.addActionListener(this);
three=new JButton("3");
three.setBackground(Color.LIGHT_GRAY);
three.setFont(new Font("Serif", Font.BOLD, 20));
three.setForeground(Color.black);
buttonpanel.add(three);
three.addActionListener(this);
min=new JButton("-");
min.setBackground(Color.LIGHT_GRAY);
min.setFont(new Font("Serif", Font.BOLD, 30));
min.setForeground(Color.black);
buttonpanel.add(min);
min.addActionListener(this);

mm=new JButton("M-");
mm.setBackground(Color.LIGHT_GRAY);
mm.setFont(new Font("Serif", Font.BOLD, 20));
mm.setForeground(Color.black);
buttonpanel.add(mm);
mm.addActionListener(this);
zero=new JButton("0");
zero.setBackground(Color.LIGHT_GRAY);
zero.setFont(new Font("Serif", Font.BOLD, 20));
zero.setForeground(Color.black);
buttonpanel.add(zero);
zero.addActionListener(this);
plmi=new JButton("+/-");
plmi.setBackground(Color.LIGHT_GRAY);
plmi.setFont(new Font("Serif", Font.BOLD, 30));
plmi.setForeground(Color.black);
buttonpanel.add(plmi);
plmi.addActionListener(this);
poin=new JButton(".");
buttonpanel.add(poin);
poin.setBackground(Color.LIGHT_GRAY);
poin.setFont(new Font("Serif", Font.BOLD, 30));
poin.setForeground(Color.black);
poin.addActionListener(this);
plus=new JButton("+");
plus.setBackground(Color.LIGHT_GRAY);
plus.setFont(new Font("Serif", Font.BOLD, 30));
plus.setForeground(Color.black);
buttonpanel.add(plus);
plus.addActionListener(this);


rec=new JButton("1/x");
rec.setBackground(Color.LIGHT_GRAY);
rec.setFont(new Font("Serif", Font.BOLD, 20));
rec.setForeground(Color.black);
buttonpanel.add(rec);
rec.addActionListener(this);
sqrt=new JButton("2√x");
sqrt.setBackground(Color.LIGHT_GRAY);
sqrt.setFont(new Font("Serif", Font.BOLD, 20));
sqrt.setForeground(Color.black);
buttonpanel.add(sqrt);
sqrt.addActionListener(this);
lg=new JButton("log");
buttonpanel.add(lg);
lg.setBackground(Color.LIGHT_GRAY);
lg.setFont(new Font("Serif", Font.BOLD, 20));
lg.setForeground(Color.black);
lg.addActionListener(this);
div=new JButton("/");
div.addActionListener(this);
div.setBackground(Color.LIGHT_GRAY);
div.setFont(new Font("Serif", Font.BOLD, 30));
div.setForeground(Color.black);
buttonpanel.add(div);
eq=new JButton("=");
eq.setBackground(Color.LIGHT_GRAY);
eq.setFont(new Font("Serif", Font.BOLD, 30));
eq.setForeground(Color.black);
buttonpanel.add(eq);
eq.addActionListener(this);


/////////////////////////////////////////
sin1=new JButton("sin");
sin1.setBackground(Color.LIGHT_GRAY);
sin1.setFont(new Font("Serif", Font.BOLD, 20));
sin1.setForeground(Color.black);
buttonpanel.add(sin1);
sin1.addActionListener(this);
cos1=new JButton("cos");
cos1.setBackground(Color.LIGHT_GRAY);
cos1.setFont(new Font("Serif", Font.BOLD, 20));
cos1.setForeground(Color.black);
buttonpanel.add(cos1);
cos1.addActionListener(this);
tan1=new JButton("tan");
tan1.setBackground(Color.LIGHT_GRAY);
tan1.setFont(new Font("Serif", Font.BOLD, 20));
tan1.setForeground(Color.black);
buttonpanel.add(tan1);
tan1.addActionListener(this);
pow2=new JButton("x^2");
pow2.setBackground(Color.LIGHT_GRAY);
pow2.setFont(new Font("Serif", Font.BOLD, 20));
pow2.setForeground(Color.black);
buttonpanel.add(pow2);
pow2.addActionListener(this);
pow3=new JButton("x^3");
pow3.setBackground(Color.LIGHT_GRAY);
pow3.setFont(new Font("Serif", Font.BOLD, 20));
pow3.setForeground(Color.black);
buttonpanel.add(pow3);
pow3.addActionListener(this);
exp=new JButton("Exp");
exp.setBackground(Color.LIGHT_GRAY);
exp.setFont(new Font("Serif", Font.BOLD, 20));
buttonpanel.add(exp);
exp.setForeground(Color.black);
exp.addActionListener(this);
////////////////////////////////////////
buttonpanel.setLayout(null);

buttonpanel.setBounds(0,0,600,300);
jtx.setBounds(20, 30, 615,45);
pow2.setBounds(20, 90, 75, 40);
pow3.setBounds(110, 90, 75, 40);
lg.setBounds(200, 90, 75, 40);
seven.setBounds(20, 140, 75, 40);
eight.setBounds(110, 140, 75, 40);
nine.setBounds(200, 140, 75, 40);
four.setBounds(20, 190, 75, 40);
five.setBounds(110, 190, 75, 40);
six.setBounds(200, 190, 75, 40);
two.setBounds(110, 240, 75, 40);
one.setBounds(20, 240, 75, 40);
three.setBounds(200, 240, 75, 40);
plus.setBounds(290, 90, 75, 40);
min.setBounds(290, 140, 75, 40);
div.setBounds(290, 190, 75, 40);
mul.setBounds(290, 240, 75, 40);
off1.setBounds(380, 90, 75, 40);
clr.setBounds(380, 140, 75, 40);
sqrt.setBounds(380,190, 75, 40);
rec.setBounds(380,240, 75, 40);
mr.setBounds(470,90, 75, 40);
mc.setBounds(470,140, 75, 40);
mp.setBounds(470,190, 75, 40);
mm.setBounds(470,240, 75, 40);
sin1.setBounds(560,90, 75, 40);
cos1.setBounds(560,140, 75, 40);
tan1.setBounds(560,190, 75, 40);
csh.setBounds(560,240, 75, 40);
poin.setBounds(20,290, 75, 40);
zero.setBounds(110,290, 75, 40);
eq.setBounds(200,290, 75, 40);
plmi.setBounds(290,290, 75, 40);
exp.setBounds(380,290, 75, 40);
tnh.setBounds(470,290, 75, 40);
snh.setBounds(560,290, 75, 40);



/////////////////////////////////////


/////////////////////////////////

cont.add("Center",buttonpanel);

}
public void actionPerformed(ActionEvent e)
{
String s=e.getActionCommand();

if(s.equals("Exit"))
{
System.exit(0);
}
if(s.equals("1"))
{
if(z==0)
{
jtx.setText(jtx.getText()+"1");
}
else
{
jtx.setText("");
jtx.setText(jtx.getText()+"1");
z=0;
}
}
if(s.equals("2"))
{
if(z==0)
{
jtx.setText(jtx.getText()+"2");
}
else
{
jtx.setText("");
jtx.setText(jtx.getText()+"2");
z=0;
}
}
if(s.equals("3"))
{
if(z==0)
{
jtx.setText(jtx.getText()+"3");
}
else
{
jtx.setText("");
jtx.setText(jtx.getText()+"3");
z=0;
}
}
if(s.equals("4"))
{
if(z==0)
{
jtx.setText(jtx.getText()+"4");
}
else
{
jtx.setText("");
jtx.setText(jtx.getText()+"4");
z=0;
}
}
if(s.equals("5"))
{
if(z==0)
{
jtx.setText(jtx.getText()+"5");
}
else
{
jtx.setText("");
jtx.setText(jtx.getText()+"5");
z=0;
}
}
if(s.equals("6"))
{
if(z==0)
{
jtx.setText(jtx.getText()+"6");
}
else
{
jtx.setText("");
jtx.setText(jtx.getText()+"6");
z=0;
}
}
if(s.equals("7"))
{
if(z==0)
{
jtx.setText(jtx.getText()+"7");
}
else
{
jtx.setText("");
jtx.setText(jtx.getText()+"7");
z=0;
}
}
if(s.equals("8"))
{
if(z==0)
{
jtx.setText(jtx.getText()+"8");
}
else
{
jtx.setText("");
jtx.setText(jtx.getText()+"8");
z=0;
}
}
if(s.equals("9"))
{
if(z==0)
{
jtx.setText(jtx.getText()+"9");
}
else
{
jtx.setText("");
jtx.setText(jtx.getText()+"9");
z=0;
}
}
if(s.equals("0"))
{
if(z==0)
{
jtx.setText(jtx.getText()+"0");
}
else
{
jtx.setText("");
jtx.setText(jtx.getText()+"0");
z=0;
}
}
if(s.equals("AC"))
{
jtx.setText("");
x=0;
y=0;
z=0;
}
if(s.equals("log"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
a=Math.log(Double.parseDouble(jtx.getText()));
jtx.setText("");
jtx.setText(jtx.getText() + a);
}
}
if(s.equals("1/x"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
a=1/Double.parseDouble(jtx.getText());
jtx.setText("");
jtx.setText(jtx.getText() + a);
}
}
if(s.equals("Exp"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
a=Math.exp(Double.parseDouble(jtx.getText()));
jtx.setText("");
jtx.setText(jtx.getText() + a);
}
}
if(s.equals("x^2"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
a=Math.pow(Double.parseDouble(jtx.getText()),2);
jtx.setText("");
jtx.setText(jtx.getText() + a);
}
}
if(s.equals("x^3"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
a=Math.pow(Double.parseDouble(jtx.getText()),3);
jtx.setText("");
jtx.setText(jtx.getText() + a);
}
}

if(s.equals("off"))
{
if(jtx.getText().equals(""))
{
System.exit(0);
}
else
{
	System.exit(0);
}
}


if(s.equals("+/-"))
{
if(x==0)
{
jtx.setText("-"+jtx.getText());
x=1;
}
else
{
jtx.setText(jtx.getText());
}
}
if(s.equals("."))
{
if(y==0)
{
jtx.setText(jtx.getText()+".");
y=1;
}
else
{
jtx.setText(jtx.getText());
}
}
if(s.equals("+"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
temp=0;
ch='+';
}
else
{
temp=Double.parseDouble(jtx.getText());
jtx.setText("");
ch='+';
y=0;
x=0;
}
jtx.requestFocus();
}
if(s.equals("-"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
temp=0;
ch='-';
}
else
{
x=0;
y=0;
temp=Double.parseDouble(jtx.getText());
jtx.setText("");
ch='-';
}
jtx.requestFocus();
}
if(s.equals("/"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
temp=1;
ch='/';
}
else
{
x=0;
y=0;
temp=Double.parseDouble(jtx.getText());
ch='/';
jtx.setText("");
}
jtx.requestFocus();
}
if(s.equals("*"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
temp=1;
ch='*';
}
else
{
x=0;
y=0;
temp=Double.parseDouble(jtx.getText());
ch='*';
jtx.setText("");
}
jtx.requestFocus();
}
if(s.equals("MC"))
{
m1=0;
jtx.setText("");
}
if(s.equals("MR"))
{
jtx.setText("");
jtx.setText(jtx.getText() + m1);
}
if(s.equals("M+"))
{
if(k==1)
{
m1=Double.parseDouble(jtx.getText());
k++;
}
else
{
m1+=Double.parseDouble(jtx.getText());
jtx.setText(""+m1);
}
}
if(s.equals("M-"))
{
if(k==1)
{
m1=Double.parseDouble(jtx.getText());
k++;
}
else
{
m1-=Double.parseDouble(jtx.getText());
jtx.setText(""+m1);
}
}
if(s.equals("Sqrt"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
a=Math.sqrt(Double.parseDouble(jtx.getText()));
jtx.setText("");
jtx.setText(jtx.getText() + a);
}
}
if(s.equals("sin"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
a=Math.sin(Double.parseDouble(jtx.getText()));
jtx.setText("");
jtx.setText(jtx.getText() + a);
}
}

if(s.equals("sinh"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
a=Math.sinh(Double.parseDouble(jtx.getText()));
jtx.setText("");
jtx.setText(jtx.getText() + a);
}
}

if(s.equals("cos1"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
a=Math.cos(Double.parseDouble(jtx.getText()));
jtx.setText("");
jtx.setText(jtx.getText() + a);
}
}

if(s.equals("cosh"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
a=Math.cosh(Double.parseDouble(jtx.getText()));
jtx.setText("");
jtx.setText(jtx.getText() + a);
}
}

if(s.equals("tan"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
a=Math.tan(Double.parseDouble(jtx.getText()));
jtx.setText("");
jtx.setText(jtx.getText() + a);
}
}

if(s.equals("tanh"))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
a=Math.tanh(Double.parseDouble(jtx.getText()));
jtx.setText("");
jtx.setText(jtx.getText() + a);
}
}


if(s.equals("="))
{
if(jtx.getText().equals(""))
{
jtx.setText("");
}
else
{
temp1 = Double.parseDouble(jtx.getText());
switch(ch)
{
case '+':
result=temp+temp1;
break;
case '-':
result=temp-temp1;
break;
case '/':
result=temp/temp1;
break;
case '*':
result=temp*temp1;
break;
}
jtx.setText("");
jtx.setText(jtx.getText() + result);
z=1;
}
}
jtx.requestFocus();
}
public static void main(String args[])
{
calculator n=new calculator();
n.setTitle("CALCULATOR");
n.setSize(660,400);
n.setLocationRelativeTo(null);
n.setResizable(false);
n.setVisible(true);
}
private static void open(URI uri) {
    if (Desktop.isDesktopSupported()) {
      try {
        Desktop.getDesktop().browse(uri);
      } catch (IOException e) { /* TODO: error handling */ }
    } else { /* TODO: error handling */ }
  }
}