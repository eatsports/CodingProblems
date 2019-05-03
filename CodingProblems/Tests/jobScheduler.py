import time


# Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.

def job_scheduler(function, sleep_time):
    time.sleep(sleep_time / 1000)
    return function()


def add(a, b):
    return a + b


result = job_scheduler(lambda: add(20, 40), 3000)
print(result)
