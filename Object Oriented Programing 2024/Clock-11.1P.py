import time
import os

class Clock:
    def __init__(self): #used to initialise Clock object
        self._second = Counter("second")
        self._minute = Counter("minute")
        self._hour = Counter("hour")

    def tick(self):
        self._second.increment()

        if self._second.tick > 59:
            self._second.reset()
            self._minute.increment()

            if self._minute.tick > 59:
                self._minute.reset()
                self._hour.increment()

                if self._hour.tick > 23:
                    self.reset()

    def reset(self):
        self._second.reset()
        self._minute.reset()
        self._hour.reset()

    def current_time(self): #prints format 00:00:00
        return f"{self._hour.tick:02}:{self._minute.tick:02}:{self._second.tick:02}"
    
class Counter:
    def __init__(self, name): #used to initialise Counter object
        self._name = name
        self._count = 0

    @property
    def name(self):
        return self._name

    def increment(self):
        self._count += 1
        return self._count

    def reset(self):
        self._count = 0
        return self._count

    @property
    def tick(self):
        return self._count

#Equivalent to Program Class
if __name__ == "__main__":
    clock = Clock()
    
    for _ in range(86400):  #86400 seconds = 24 hours
        time.sleep(0.01)  #waits 10 milliseconds before ticking
        os.system('cls' if os.name == 'nt' else 'clear') #clears terminal on windows and Unix
        clock.tick()
        print(clock.current_time())