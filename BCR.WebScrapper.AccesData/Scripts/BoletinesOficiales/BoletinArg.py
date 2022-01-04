#!/usr/bin/python
# -*- coding: utf-8 -*-

import os
import time
import selenium
from selenium import webdriver
#import Constantes as cons


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
         self.get("https://www.boletinoficial.gob.ar/seccion/segunda")
     
     def scroll_page(self):
         SCROLL_PAUSE_TIME = 3
         last_height = self.execute_script("return document.body.scrollHeight")
         while True:
             self.execute_script("window.scrollTo(0, document.body.scrollHeight);")
             time.sleep(SCROLL_PAUSE_TIME)
             new_height = self.execute_script("return document.body.scrollHeight")
             if new_height == last_height:
                 break
             last_height = new_height
     
     def close_page(self):
         self.quit()

     def empresas_report(self):
         content  = self.find_elements_by_tag_name('p.item')
         empresas = []
         for empresa in content:
             empresas.append(empresa.text)
         return empresas


