#!/usr/bin/python
# -*- coding: utf-8 -*-

import os
import time
import selenium
from selenium import webdriver

import Constantes as cons


class BoletinBot (selenium.webdriver.Chrome):
     def __init__(self , driver_path = "C:/Users/german.obregon/Documents/chromedriver_win32" , teardown = False):
         self.driver_paht = driver_path
         self.teardown = teardown
         os.environ['PATH'] += os.pathsep + self.driver_paht
         super(BoletinBot , self).__init__()
         self.maximize_window()
         self.implicitly_wait(8)
     
     def __exit__(self , exce_type , exc_val , exc_tb):
         if self.teardown:
             self.quit()
     
     def get_url(self):
         self.get(cons.BOLETIN_STAFE_URL);
       
     
     def close_page(self):
         self.quit()
     
     def empresas_report(self):
         content  = self.find_elements_by_tag_name('b')
         empresas = []
         for empresa in content:
             empresas.append(empresa.text)
         return empresas