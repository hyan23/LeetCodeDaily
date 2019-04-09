// SubstringWithConcatenationOpt.go
// Author: hyan23
// 2019.04.09
// https://leetcode.com/problems/substring-with-concatenation-of-all-words/

package main

import "fmt"

/*
func findSubstring(s string, words []string) []int {
	if len(s) == 0 || len(words) == 0 {
		return []int{}
	}

	length := len(words[0])
	indices := []int{}
	if len(s) < len(words)*length {
		return indices
	}

	m := make(map[string]int)
	for _, word := range words {
		m[word]++
	}

	for i := 0; i < length; i++ {
		for j := i; j < len(s); {
			m2 := make(map[string]int)
			pos := make(map[string]int)
			count := 0

			notFound := false
			duplicate := false

			k := j
			fragment := s
			for ; k+length <= len(s); k += length {
				fragment = s[k : k+length]
				if _, ok := m[fragment]; ok {
					m2[fragment]++
					count++
					if _, ok2 := pos[fragment]; !ok2 {
						pos[fragment] = k
					}
					if m2[fragment] > m[fragment] {
						duplicate = true
						break
					}
				} else {
					notFound = true
					break
				}
				if count == len(words) {
					indices = append(indices, j)
					break
				}
			}
			if notFound {
				j = k + length
			} else if duplicate {
				j = pos[fragment] + length
			} else {
				j = j + length
			}
		}
	}
	return indices
}
*/

func findSubstring(s string, words []string) []int {
	if len(s) == 0 || len(words) == 0 {
		return []int{}
	}

	length := len(words[0])
	subStrLength := len(words) * length
	if len(s) < subStrLength {
		return []int{}
	}

	m := make(map[string]int)
	for _, word := range words {
		m[word]++
	}

	indices := []int{}

	for i := 0; i < length; i++ {
		m2 := make(map[string]int)
		keys := []string{}
		count := 0
		pos := make(map[string]int)
		for j := i; j < len(s); {
			notFound := false
			duplicate := false
			match := false

			k := j
			fragment := s
			for ; k+length <= len(s); k += length {
				fragment = s[k : k+length]
				if _, ok := m[fragment]; ok {
					keys = append(keys, fragment)
					m2[fragment]++
					count++
					if _, ok2 := pos[fragment]; !ok2 {
						pos[fragment] = k
					}
					if m2[fragment] > m[fragment] {
						duplicate = true
						break
					}
				} else {
					notFound = true
					break
				}
				if count == len(words) {
					indices = append(indices, k+length-subStrLength)
					match = true
					break
				}
			}
			if notFound {
				j = k + length
			} else if duplicate {
				j = pos[fragment] + length
			} else if match {
				first := keys[0]
				keys = keys[1:]
				pos[first] += length
				m2[first]--
				count--
				j = k + length
			} else {
				j = j + length
			}
			if !match {
				m2 = make(map[string]int)
				keys = []string{}
				count = 0
				pos = make(map[string]int)
			}
		}
	}
	return indices
}

func main() {
	fmt.Println(findSubstring("barfoothefoobarman", []string{"foo", "bar"}))
	fmt.Println(findSubstring("wordgoodgoodgoodbestword", []string{"word", "good", "best", "word"}))
	fmt.Println(findSubstring("barfoofoobarthefoobarman", []string{"bar", "foo", "the"}))
	fmt.Println(findSubstring("wordgoodgoodgoodbestword", []string{"word", "good", "best", "good"}))
	fmt.Println(findSubstring("wordgoodgoodgoodbestword", []string{"good"}))
	fmt.Println(findSubstring("oooooooooooooooaooooooaaa", []string{"ooo", "ooo"}))
	fmt.Println(findSubstring("aaa", []string{"a", "a"}))
}
