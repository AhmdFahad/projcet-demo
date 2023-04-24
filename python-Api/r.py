import redis
#redis://default:redispw@localhost:49153
clint = redis.Redis(host='localhost', port=49155, username='default', password='redispw',decode_responses=True)


