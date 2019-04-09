// SubstringWithConcatenationOpt.go
// Author: hyan23
// 2019.04.09
// https://leetcode.com/problems/substring-with-concatenation-of-all-words/

package main

import "fmt"

func findSubstring(s string, words []string) []int {
	if len(s) == 0 || len(words) == 0 {
		return []int{}
	}

	m := make(map[string]int)
	for _, word := range words {
		m[word]++
	}

	length := len(words[0])
	indices := []int{}

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

func main() {
	fmt.Println(findSubstring("barfoothefoobarman", []string{"foo", "bar"}))
	fmt.Println(findSubstring("wordgoodgoodgoodbestword", []string{"word", "good", "best", "word"}))
	fmt.Println(findSubstring("barfoofoobarthefoobarman", []string{"bar", "foo", "the"}))
	fmt.Println(findSubstring("wordgoodgoodgoodbestword", []string{"word", "good", "best", "good"}))
}
