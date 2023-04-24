FROM python:3.9
WORKDIR /usr/src/app
COPY . ./
RUN cd python-Api
RUN pip install Redis fastapi uvicorn
CMD ["uvicorn", "main:app", "--host", "127.0.0.1", "--port", "8000"]