from fastapi import FastAPI
from typing import Union

import r
clint=r.clint;
print(clint.ping())

app=FastAPI()

set='Book'

@app.get('/')
def getAllBook():
    return clint.smembers(set);

@app.post('/{id}')
def addNewBook(id:str):
    return clint.sadd(set,id);

@app.delete('/{id}')
def deleteBook(id:str):
    return clint.srem(set,id)

    