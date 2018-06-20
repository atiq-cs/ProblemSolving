/***************************************************************************
* Title : Producer Consumer Demonstration
* URL   :
* Date  : 2018-03-22
* Author: Atiq Rahman
* Comp  :
* Status: Accepted
* Notes : Check comments inline
*   C++ 11, uses references instead of pointers, uses c++ mutex, locks and
*   lambda syntax
*   ref: https://codereview.stackexchange.com/q/84109
* meta  : tag-multi-threading, tag-system-mutex
***************************************************************************/
#include <iostream>
#include <thread>
#include <deque>
#include <mutex>
#include <chrono>
#include <condition_variable>
using std::deque;

std::mutex cout_mu;   // global costly mutex for non thread-safe cout

class Buffer {
public:
  /*
  * lock mutex
  * Wait till buffer has roam for new items
  * push the item into buffer
  * Unlock
  * and wake up threads
  */
  void add(int num) {
    while (true) {
      std::unique_lock<std::mutex> locker(mu);
      cond.wait(locker, [this]() { return buffer.size() < size_; });
      buffer.push_back(num);
      locker.unlock();
      cond.notify_all();
      return;
    }
  }

  /*
  * Similar to add, however now,
  * Wait till buffer is non-empty
  * remove last item from buffer
  * and wake up threads
  */
  int remove() {
    while (true) {
      std::unique_lock<std::mutex> locker(mu);
      cond.wait(locker, [this]() { return buffer.size() > 0; });
      int back = buffer.back();
      buffer.pop_back();
      locker.unlock();
      cond.notify_all();
      return back;
    }
  }
  Buffer() {}

private:
  // Add them as member variables here
  std::mutex mu;
  std::condition_variable cond;

  // Your normal variables here
  deque<int> buffer;
  const unsigned int size_ = 10;
};

class Producer {
public:
  Producer(Buffer& buffer)
    : buffer(buffer) {
  }

  void run() {
    while (true) {
      int num = std::rand() % 100;
      buffer.add(num);
      cout_mu.lock();
      std::cout << "Produced: " << num << std::endl;
      cout_mu.unlock();
      std::this_thread::sleep_for(std::chrono::milliseconds(50));
    }
  }
private:
  Buffer & buffer;
};

class Consumer {
public:
  Consumer(Buffer& buffer)
    : buffer(buffer) {
  }

  void run() {
    while (true) {
      int num = buffer.remove();
      cout_mu.lock();
      std::cout << "Consumed: " << num << std::endl;
      cout_mu.unlock();
      std::this_thread::sleep_for(std::chrono::milliseconds(50));
    }
  }

private:
  Buffer & buffer;
};

int main() {
  Buffer b;
  Producer p(b);
  Consumer c(b);

  std::thread producer_thread(&Producer::run, &p);
  std::thread consumer_thread(&Consumer::run, &c);
  producer_thread.join();
  consumer_thread.join();

  return 0;
}
