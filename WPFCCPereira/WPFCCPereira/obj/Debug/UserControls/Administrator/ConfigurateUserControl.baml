   M S B A M L   `   `   `  ����G  CWPFCCPereira, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:WPFCCPereira.UserControls.Administrator'WPFCCPereira.UserControls.Administrator  5   	   ?$clr-namespace:WPFCCPereira.ResourcesWPFCCPereira.Resources  5   	   D    >WPFCCPereira.UserControls.Administrator.ConfigurateUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Glocal5clr-namespace:WPFCCPereira.UserControls.Administrator     5   	   4res$clr-namespace:WPFCCPereira.Resources     5   	   J FWpfAnimatedGif, Version=1.4.18.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	   "  WpfAnimatedGif.ImageBehavior    AnimateInDesignMode  . $
��1920��5   	   $
��1080��5   	   .��5      � ��5   
   �� 5       �� ImageSource$' !/Images/Backgrounds/bg-blanck.jpg��6    j� Stretch$ Uniform=�6I    � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $	��400 �6   �� 5      $
��1200 �6   �� 5      $��* �6   .+�5   
   � $��1��6   .+�5      �� $��75(�5      $��Bottom=�5      $��Center=�5      $��0,0,0,0q�5      ���	#FF90C143 �� TextAlignment$ Center=�5      $
��Wrap=�5       $	��800��5!      $��Arial)�5"      $$��Configuración del dispositivo��5#      $
��Bold"�5$      5%      � 5'   
   $��2��6   .+�5(      �� $>��8Espere mientras se configura el dispositivo para iniciar��6   $��Arial)�5)      $��60(�5*      $	��Top=�5+      $��Center=�5,      $��	0,200,0,0q�5-      ���	#FF104B6D$
��Wrap=�5/      $ Center=�50      $	��900��51      $
��Bold"�6$   �� 53      -   5         ��Name$ 
GifLoadder��56         AnimatedSource$! /Images/Gif/gif-preload.gif��53        .    	AutoStart . $
��Fill=�57      $��	0,180,0,0q�58      $��Center=�59      $��Center=�5:      $	��450��5;      $	��520��5<      �� 5>      -   5         ��Name$ txt_description��5>      $��Arial)�5@      $��40(�5A      $��Bottom=�5B      $��Center=�5C      $��	0,0,0,200q�5D      ���	#FF0D679A$
��Wrap=�5F      $ Center=�5G      $
��Bold"�5H      ��5?      �� *DescriptionStatusPayPlus+5H      5I      5J      5K      