// SearchInRotatedArray.go
// Author: hyan23
// 2019.04.11
// https://leetcode.com/problems/search-in-rotated-sorted-array/

package main

import "fmt"

func search(nums []int, target int) int {
	if len(nums) == 0 {
		return -1
	}
	left, right := 0, len(nums)-1
	for left <= right {
		// fmt.Printf("%v %v\n", left, right)
		mid := (left + right) / 2
		if target > nums[mid] {
			if nums[right] >= target || nums[right] < nums[mid] {
				left = mid + 1
			} else {
				right = mid - 1
			}
		} else if target < nums[mid] {
			if nums[left] <= target || nums[right] > nums[mid] {
				right = mid - 1
			} else {
				left = mid + 1
			}
		} else {
			return mid
		}
	}
	return -1
}

func main() {
	fmt.Println(search([]int{4, 5, 6, 7, 0, 1, 2}, 0))
	fmt.Println(search([]int{4, 5, 6, 7, 0, 1, 2}, 3))
	fmt.Println(search([]int{4, 5}, 4))
	fmt.Println(search([]int{4, 5}, 5))
	fmt.Println(search([]int{4}, 4))
	fmt.Println(search([]int{4}, 5))
	fmt.Println(search([]int{4, 5, 6, 7, 8, 9, 0, 1, 2}, 4))
	fmt.Println(search([]int{4, 5, 6, 7, 8, 9, 0, 1, 2}, 5))
	fmt.Println(search([]int{4, 5, 6, 7, 8, 9, 0, 1, 2}, 6))
	fmt.Println(search([]int{4, 5, 6, 7, 8, 9, 0, 1, 2}, 7))
	fmt.Println(search([]int{4, 5, 6, 7, 8, 9, 0, 1, 2}, 8))
	fmt.Println(search([]int{4, 5, 6, 7, 8, 9, 0, 1, 2}, 9))
	fmt.Println(search([]int{7, 8, 9, 0, 1, 2, 3, 4, 5, 6}, 1))
	fmt.Println(search([]int{7, 8, 9, 0, 1, 2, 3, 4, 5, 6}, 2))
	fmt.Println(search([]int{7, 8, 9, 0, 1, 2, 3, 4, 5, 6}, 3))
	fmt.Println(search([]int{7, 8, 9, 0, 1, 2, 3, 4, 5, 6}, 4))
	fmt.Println(search([]int{7, 8, 9, 0, 1, 2, 3, 4, 5, 6}, 5))
	fmt.Println(search([]int{7, 8, 9, 0, 1, 2, 3, 4, 5, 6}, 6))
	fmt.Println(search([]int{7, 8, 9, 0, 1, 2, 3, 4, 5, 6}, 7))
}
